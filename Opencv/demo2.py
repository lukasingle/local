import cv2 as cv2


img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")

rows, cols = img.shape[:2]
size = (int(cols*2), int(rows*2))
rst = cv2.resize(img, size)

#rst = cv2.resize(img, None, fx=2, fy=0.5)

cv2.imshow("lena", img)
cv2.imshow("rst", rst)
cv2.waitKey(0)
cv2.destroyAllWindows()
