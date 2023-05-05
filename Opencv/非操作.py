import cv2
import numpy as np

#创建一张图片
img = np.zeros((200, 200), np.uint8)

img[50:150, 50:150] = 255
#图像的非操作
new_img = cv2.bitwise_not(img)


cv2.imshow("new_img", new_img)
cv2.imshow("img", img)
cv2.waitKey(0)
cv2.destroyAllWindows()
