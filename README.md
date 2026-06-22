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




1. Nhóm Authentication (Xác thực)
Đăng ký: Tạo tài khoản mới với Email/Password.

Đăng nhập: Xác thực người dùng qua Firebase Auth.

Quên mật khẩu: Gửi email khôi phục mật khẩu.

Đăng xuất: Hủy phiên làm việc hiện tại.

Quản lý Profile: Cập nhật thông tin cá nhân (Tên hiển thị, Bio) và thay đổi ảnh đại diện/ảnh bìa (lưu trên Firebase Storage).

2. Nhóm Posts (Bài đăng - Cốt lõi)
Đăng bài: Tạo bài viết mới bao gồm nội dung văn bản và đính kèm ảnh/video.

Feed (News Feed): Truy vấn và hiển thị danh sách bài viết từ bạn bè theo thứ tự thời gian.

Chỉnh sửa bài viết: Cập nhật nội dung cho bài đăng của chính mình.

Xóa bài viết: Gỡ bỏ bài viết cá nhân khỏi hệ thống.

3. Nhóm Comments (Bình luận - Cốt lõi)
Thêm bình luận: Nhúng bình luận vào bài viết cụ thể.

Hiển thị: Tải và hiển thị danh sách bình luận (kèm thông tin người bình luận và thời gian).

Xóa bình luận: Hủy bình luận cá nhân đã đăng.

4. Nhóm Friends (Kết bạn - Cốt lõi)
Gửi lời mời: Gửi yêu cầu kết bạn đến người dùng khác.

Quản lý lời mời: Chấp nhận hoặc Từ chối yêu cầu kết bạn nhận được.

Danh sách bạn bè: Truy vấn và hiển thị danh sách các kết nối đã xác nhận.

Hủy kết bạn: Xóa bỏ mối quan hệ kết bạn hiện có.

Tìm kiếm: Tìm kiếm người dùng khác theo tên hiển thị hoặc email.

5. Nhóm Interactions (Tương tác & Real-time)
Like/Unlike: Thả tim hoặc bỏ thả tim cho bài viết.

Share: Chia sẻ nội dung từ bài viết khác về trang cá nhân.

Thông báo (Real-time): Sử dụng SignalR để đẩy thông báo tức thì khi có hoạt động mới (Like, Comment, Kết bạn).