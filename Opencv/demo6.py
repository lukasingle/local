import cv2 as cv2
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
t1, dst1 = cv2.threshold(gray, 40, 255, cv2.THRESH_BINARY)
t2, dst2 = cv2.threshold(gray, 40, 255, cv2.THRESH_BINARY_INV)
cv2.imshow("img", img)
cv2.imshow("dst1", dst1)
cv2.imshow("dst2", dst2)

cv2.waitKey(0)
cv2.destroyAllWindows()