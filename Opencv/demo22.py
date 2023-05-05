import cv2 as cv2
import matplotlib.pyplot as plt
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
#灰度图
img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

#傅里叶变换
res = cv2.dft(np.float32(img), flags=cv2.DFT_COMPLEX_OUTPUT)
#调整零频率分量位置
res = np.fft.fftshift(res)
#处理实数和虚数部分并转换成图片
res_img = 20 * np.log(cv2.magnitude(res[:,:,0], res[:,:,1]))

plt.figure(figsize=(20,8), dpi=80)
plt.subplot(121)
plt.imshow(img, cmap='gray')
plt.subplot(122)
plt.imshow(res_img,cmap='gray')
plt.savefig('456.png')








