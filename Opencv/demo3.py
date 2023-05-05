import cv2 as cv
import numpy as np


# cv.rectangle(b1, (50,50), (400, 400), (0, 0, 255), 2, 8, 0)
# cv.circle(b1, (200, 200), 50, (255, 100, 0), 2, 8, 0)

def drawing_demo():
    b1 = cv.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
    cv.line(b1,(50,50), (400, 400), (0, 0, 255), 2, 8, 0)
    cv.putText(b1,"99% face", (50, 50), cv.FONT_HERSHEY_SIMPLEX, 1.0, (0,255,255),2,8)
    cv.imshow("input",b1)
    cv.waitKey(0)
    cv.destroyAllWindows()

if __name__ =="__main__":
    drawing_demo()