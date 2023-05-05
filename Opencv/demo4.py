import cv2 as cv
import numpy as np


# cv.rectangle(b1, (50,50), (400, 400), (0, 0, 255), 2, 8, 0)
# cv.circle(b1, (200, 200), 50, (255, 100, 0), 2, 8, 0)

def pixel_demo():
    image = cv.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
    cv.imshow("input",image)
    h, w, c = image.shape
    for row in range(h):
        for col in range(w):
            b, g, r = image[row, col]
            image[row, col] = (255-b, 255-g, 255-r)
    cv.imshow("result", image)
    cv.waitKey(0)
    cv.destroyAllWindows()

if __name__ =="__main__":
    pixel_demo()