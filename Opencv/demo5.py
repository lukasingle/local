import cv2 as cv
import numpy as np


# cv.rectangle(b1, (50,50), (400, 400), (0, 0, 255), 2, 8, 0)
# cv.circle(b1, (200, 200), 50, (255, 100, 0), 2, 8, 0)

def pixel_demo():
    image = cv.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
    cv.imshow("input",image)
    h, w, c = image.shape
    blank = np.zeros_like(image)
    blank[:,:] = (2, 2, 2)
    cv.imshow("blank", blank)
    result = cv.multiply(image, blank)
    cv.imshow("result", result)
    cv.waitKey(0)
    cv.destroyAllWindows()

if __name__ =="__main__":
    pixel_demo()