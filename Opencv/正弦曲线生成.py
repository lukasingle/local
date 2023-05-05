import numpy as np
import cv2
#设置图像的宽为628
row = 628
#设置图像的长为628
col = 628
#创建长宽分别为200和200的白色图像
pic = np.ones((row, col)) * 255
#设置正弦曲线中的参数A1
A1 = 40
#设置
phil = 180
#设置基线y0 = 300
baseline1 = 300
h = 1
#生成一个正弦函数图像
for i in range(628):
    y1 = A1 * (np.sin(i * 2 * np.pi / 628 - np.pi * 60 / 180)) + baseline1  # 创建这么一个正弦曲线
    pic[int(y1), i] = 0

cv2.imwrite('demo1.jpg',pic)

#显示生成的正弦函数
cv2.imshow("pic",pic)
cv2.waitKey(0)
cv2.destroyAllWindows()