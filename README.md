## 簡易網路聊天室，以TCP Socket實作  

* GroupChat_Server(Linux)：Ubtunu CLI版本
* GroupChat_Client(Windows)：Windows Form版本  

## 使用說明
1. **執行訊息轉發服務器(Linux)**  
```
cd "./GroupChat_Server(Linux)/"  
./server  
```
2. **連結服務器(Windows)**  
```
cd ".\GroupChat_Client(Windows)\GroupChat_Client\bin\Debug"  
.\GroupChat_Client.exe  
```

### Hint:下列紫色視窗為服務器訊息，白色視窗為聊天室客戶端 

3. **輸入服務器IP連線**  
目前服務器檔案描述符(File descriptor, FD)數量為3，代表尚未有客戶端上線，輸入服務器IP連線(當下IP 192.168.50.79)。  
<p align="center">
  <img src="https://github.com/YamGhost/GroupChat/blob/master/fig/%E8%BC%B8%E5%85%A5IP%E9%80%A3%E7%B7%9A.png"  width="80%"/>
</p>

4. **連線服務器**  
服務器檔案描述符(File descriptor, FD)數量由3變為4，連線來自192.168.50.227的客戶端，以此類推FD數量由4變為5，連線來自192.168.50.59的客戶端。(目前服務器連線2位使用者，以下僅展示1位使用者的聊天室客戶端)  
<p align="center">
  <img src="https://github.com/YamGhost/GroupChat/blob/master/fig/%E5%B7%B2%E9%80%A3%E7%B7%9A%E8%81%8A%E5%A4%A9%E5%AE%A4.png"  width="80%"/>
</p>

5. **服務器轉發訊息**  
在客戶端輸入訊息後按下Send發送至聊天室，第一位來自192.168.50.227的使用者發送"Hi! I am Jane."，另一位來自192.168.50.59的使用者發送"Hello! I'm Peter."，由服務端轉發至每位使用者的聊天室內。
<p align="center">
  <img src="https://github.com/YamGhost/GroupChat/blob/master/fig/%E7%99%BC%E9%80%81%E8%A8%8A%E6%81%AF.png"  width="80%"/>
</p>

6. **登出聊天室**  
按下客戶端loginout即可登出聊天室回到登入畫面，服務端檔案描述符(File descriptor, FD)數量也由4變為3，代表客戶端已下線。
<p align="center">
  <img src="https://github.com/YamGhost/GroupChat/blob/master/fig/%E7%99%BB%E5%87%BA%E8%81%8A%E5%A4%A9%E5%AE%A4.png"  width="80%"/>
</p>

## **異常處理**
如果服務器主動關閉，將導致所有客戶端自動離線且無法再次連線。
<p align="center">
  <img src="https://github.com/YamGhost/GroupChat/blob/master/fig/%E6%9C%8D%E5%8B%99%E5%99%A8%E4%B8%BB%E5%8B%95%E9%97%9C%E9%96%89%E4%B8%A6%E5%98%97%E8%A9%A6%E5%86%8D%E6%AC%A1%E9%80%A3%E7%B7%9A.png"  width="80%"/>
</p>
