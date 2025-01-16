import socket
import cv2
import numpy as np
import tensorflow as tf
import tensorflow_hub as hub

KEYPOINT_THRESHOLD = 0.2
previous_y = None  # 腰のY座標を保存するための変数

HOST = '127.0.0.1'
PORT = 50553
client = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

def main():
    model = hub.load('https://tfhub.dev/google/movenet/multipose/lightning/1')
    movenet = model.signatures['serving_default']
    
    cap = cv2.VideoCapture(0)
    cap.set(cv2.CAP_PROP_BUFFERSIZE, 1)
    
    while True:
        ret, frame = cap.read()
        if not ret:
            break

        keypoints_list, scores_list, bbox_list = run_inference(movenet, frame)
        result_image = render(frame, keypoints_list, scores_list, bbox_list)
        judge_position_and_jump(frame, bbox_list, keypoints_list, scores_list)

        cv2.namedWindow("image", cv2.WINDOW_FULLSCREEN)
        cv2.imshow('image', result_image)
        key = cv2.waitKey(1) & 0xFF
        if key == ord('q'):
            break
    
    cap.release()

def run_inference(model, image):
    input_image = cv2.resize(image, dsize=(256, 256))
    input_image = cv2.cvtColor(input_image, cv2.COLOR_BGR2RGB)
    input_image = np.expand_dims(input_image, 0)
    input_image = tf.cast(input_image, dtype=tf.int32)

    outputs = model(input_image)
    keypoints = np.squeeze(outputs['output_0'].numpy())
    image_height, image_width = image.shape[:2]
    keypoints_list, scores_list, bbox_list = [], [], []

    for kp in keypoints:
        keypoints = []
        scores = []
        for index in range(17):
            kp_x = int(image_width * kp[index*3+1])
            kp_y = int(image_height * kp[index*3+0])
            score = kp[index*3+2]
            keypoints.append([kp_x, kp_y])
            scores.append(score)
        bbox_ymin = int(image_height * kp[51])
        bbox_xmin = int(image_width * kp[52])
        bbox_ymax = int(image_height * kp[53])
        bbox_xmax = int(image_width * kp[54])
        bbox_score = kp[55]

        keypoints_list.append(keypoints)
        scores_list.append(scores)
        bbox_list.append([bbox_xmin, bbox_ymin, bbox_xmax, bbox_ymax, bbox_score])

    return keypoints_list, scores_list, bbox_list

def render(image, keypoints_list, scores_list, bbox_list):
    render = image.copy()
    for i, (keypoints, scores, bbox) in enumerate(zip(keypoints_list, scores_list, bbox_list)):
        if bbox[4] < 0.2:
            continue

        cv2.rectangle(render, (bbox[0], bbox[1]), (bbox[2], bbox[3]), (0, 255, 0), 2)

        kp_links = [
            (0, 1), (0, 2), (1, 3), (2, 4), (0, 5), (0, 6), (5, 6), (5, 7), 
            (7, 9), (6, 8), (8, 10), (11, 12), (5, 11), (11, 13), (13, 15), 
            (6, 12), (12, 14), (14, 16)
        ]
        for kp_idx_1, kp_idx_2 in kp_links:
            kp_1 = keypoints[kp_idx_1]
            kp_2 = keypoints[kp_idx_2]
            score_1 = scores[kp_idx_1]
            score_2 = scores[kp_idx_2]
            if score_1 > KEYPOINT_THRESHOLD and score_2 > KEYPOINT_THRESHOLD:
                cv2.line(render, tuple(kp_1), tuple(kp_2), (0, 0, 255), 2)

        for idx, (keypoint, score) in enumerate(zip(keypoints, scores)):
            if score > KEYPOINT_THRESHOLD:
                cv2.circle(render, tuple(keypoint), 4, (0, 0, 255), -1)

    return render

def judge_position_and_jump(image, bbox_list, keypoints_list, scores_list):
    global previous_y
    
    image_height, image_width = image.shape[:2]
    left_threshold = image_width // 3
    right_threshold = 2 * image_width // 3

    for bbox, keypoints, scores in zip(bbox_list, keypoints_list, scores_list):
        if bbox[4] < 0.2:
            continue

        # 位置の判定
        center_x = (bbox[0] + bbox[2]) // 2

        if center_x < left_threshold:
            print("右側にいます。")
            data = "right"
        elif center_x < right_threshold:
            print("中央にいます。")
            data = "middle"
        else:
            print("左側にいます。")
            data = "left"
        
        # ジャンプの判定
        if scores[11] > KEYPOINT_THRESHOLD:  # 11は腰のキーポイント
            current_y = keypoints[11][1]  # 腰のY座標
            
            if previous_y is not None:
                if current_y < previous_y - 30:  # 30ピクセル以上上昇した場合
                    print("ジャンプしました！")
                    data = "ジャンプ"
                    
            previous_y = current_y  # 現在のY座標を保存

        client.sendto(str.encode(str(data)), (HOST, PORT))

if __name__ == '__main__':
    main()
