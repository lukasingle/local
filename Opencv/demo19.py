import cv2 as cv2
import matplotlib.pyplot as plt
import numpy as np


img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")

#灰度图
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
#二值图像
ret, thresh1 = cv2.threshold(gray,40,255,cv2.THRESH_BINARY)

#获取轮廓
image, contours, hierarchy = cv2.findContours(thresh1,cv2.RETR_TREE,cv2.CHAIN_APPROX_SIMPLE)
#分别画出轮廓
for i in range(len(contours)):
    #创建一个空白图像，用来保存轮廓信息
    mask = np.zeros(img.shape, np.uint8)
    mask = cv2.drawContours(mask, contours, i , 255, 2)
    cv2.imshow(f'{i}', mask)

cv2.imshow("hehe",img)
cv2.waitKey(0)
cv2.destroyAllWindows()







