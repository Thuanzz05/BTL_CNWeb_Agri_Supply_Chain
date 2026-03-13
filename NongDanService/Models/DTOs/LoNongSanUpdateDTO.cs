using System.ComponentModel.DataAnnotations;

namespace NongDanService.Models.DTOs
{
    public class LoNongSanUpdateDTO
    {
        [Range(0, double.MaxValue, ErrorMessage = "Số lượng hiện tại không được âm")]
        public decimal? SoLuongHienTai { get; set; }

        public DateTime? NgayThuHoach { get; set; }

        public DateTime? HanSuDung { get; set; }

        [StringLength(255, ErrorMessage = "Mã QR không được vượt quá 255 ký tự")]
        public string? MaQR { get; set; }

        [StringLength(30, ErrorMessage = "Trạng thái không được vượt quá 30 ký tự")]
        public string? TrangThai { get; set; }
    }
}