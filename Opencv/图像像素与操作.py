import cv2
import numpy as np
#读取图像
img = cv2.imread("104.jpg")
demo = cv2.imread("demo1.jpg")

#设置成灰度图
gray1 = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
gray2 = cv2.cvtColor(demo, cv2.COLOR_BGR2GRAY)

#二值化
t1, dst1 = cv2.threshold(gray1, 40, 255, cv2.THRESH_BINARY)

t1, dst2 = cv2.threshold(gray2, 40, 255, cv2.THRESH_BINARY)

cv2.imshow("dst1",dst1)

cv2.imshow("dst2",dst2)
#图像与操作
new_img = cv2.bitwise_and(dst1,dst2)
cv2.imshow("new_img",new_img)



cv2.waitKey(0)
cv2.destroyAllWindows()