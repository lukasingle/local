import cv2 as cv

# def read_demo():
#     image = cv.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
#
#     cv.imshow("input", image)
#     cv.waitKey(0)
#     cv.destroyAllWindows()

def colorspace_demo():
    b1 = cv.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
    print(b1.shape)
    cv.imshow("input",b1)
    hsv = cv.cvtColor(b1,cv.COLOR_BGR2HSV)
    cv.imshow("hsv",hsv)
    mask = cv.inRange(hsv,(0,0,0),(180,255,46))
    cv.imshow("mask",mask)

    cv.waitKey(0)
    cv.destroyAllWindows()

if __name__ == "__main__":
    colorspace_demo()