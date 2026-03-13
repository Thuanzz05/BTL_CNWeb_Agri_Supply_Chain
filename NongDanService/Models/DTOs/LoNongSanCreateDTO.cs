using System.ComponentModel.DataAnnotations;

namespace NongDanService.Models.DTOs
{
    public class LoNongSanCreateDTO
    {
        [Required(ErrorMessage = "Mã trang trại là bắt buộc")]
        public int MaTrangTrai { get; set; }

        [Required(ErrorMessage = "Mã sản phẩm là bắt buộc")]
        public int MaSanPham { get; set; }

        [Required(ErrorMessage = "Số lượng ban đầu là bắt buộc")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Số lượng ban đầu phải lớn hơn 0")]
        public decimal SoLuongBanDau { get; set; }

        [Required(ErrorMessage = "Ngày thu hoạch là bắt buộc")]
        public DateTime NgayThuHoach { get; set; }

        [Required(ErrorMessage = "Hạn sử dụng là bắt buộc")]
        public DateTime HanSuDung { get; set; }

        [StringLength(255, ErrorMessage = "Mã QR không được vượt quá 255 ký tự")]
        public string? MaQR { get; set; }
    }
}