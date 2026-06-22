# 🌐 Social Network Project

> *Kết nối mọi người, chia sẻ đam mê - Hệ thống Mạng xã hội hiện đại.*

---

## 🛠️ Kiến trúc hệ thống
Dự án áp dụng mô hình **MVC (Model-View-Controller)** nhằm tối ưu hóa hiệu năng và khả năng bảo trì:
* **Model:** Định nghĩa các thực thể dữ liệu (`User`, `Post`, `Comment`, `Friendship`) và tầng Firebase Service để tương tác với Realtime Database & Firestore.
* **View:** Giao diện người dùng tương tác, cập nhật dữ liệu trực tiếp theo thời gian thực.
* **Controller:** Quản lý luồng xử lý từ xác thực tài khoản, đăng bài, kết bạn cho đến xử lý tương tác thông qua SignalR.

---

## 💡 Hệ thống tính năng

### Nhóm Cốt lõi
* **Posts:** Đăng bài (text/image), hiển thị News Feed, chỉnh sửa/xóa bài viết cá nhân.
* **Comments:** Hệ thống bình luận nhúng, hiển thị thời gian thực và quản lý bình luận cá nhân.
* **Friends:** Quản lý kết nối qua trạng thái (Pending/Accepted), danh sách bạn bè và hủy kết nối.

### Nhóm Bổ sung
* **Authentication:** Đăng ký, Đăng nhập (Firebase Auth), Quản lý Profile (Avatar/Bio).
* **Interactions:** Like/Unlike, Share bài viết.
* **Real-time Notifications:** Thông báo tức thời khi có tương tác (SignalR).
* **Search:** Tìm kiếm bạn bè theo tên hoặc email.

---

## 🚀 Hướng phát triển
1. **AI Recommendation:** Xây dựng hệ thống gợi ý bạn bè thông minh dựa trên thuật toán đồ thị.
2. **Multimedia & Storage:** Tối ưu hóa lưu trữ ảnh và video thông qua Firebase Storage.
3. **Chat System:** Xây dựng khung chat trực tuyến thời gian thực.
4. **AI Assistant:** Tích hợp Vbee AIVoice để điều khiển giao diện bằng giọng nói.
