import cv2 as cv2
import numpy as np
#读取图片
img = cv2.imread("104.jpg")
#设置成灰度图
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
#二值化
t1, dst1 = cv2.threshold(gray, 50, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)
t2, dst2 = cv2.threshold(gray, 40, 255, cv2.THRESH_BINARY_INV + cv2.THRESH_OTSU)

cv2.imshow("dst1",dst1)
cv2.imshow("",dst2)
cv2.waitKey(0)
cv2.destroyAllWindows()