import cv2 as cv2
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
cv2.imshow("img",img)
up = cv2.pyrUp(img)
cv2.imshow("up",up)
down = cv2.pyrDown(img)
cv2.imshow("down",down)

cv2.waitKey(0)
cv2.destroyAllWindows()