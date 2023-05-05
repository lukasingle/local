import cv2
import numpy as np

#导入图片
dog = cv2.imread("demo.jpg")

#创建LOGO
logo = np.zeros((200, 200, 3), np.uint8)
mask = np.zeros((200, 200), np.uint8)

