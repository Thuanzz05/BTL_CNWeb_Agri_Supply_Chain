using NongDanService.Models.DTOs;

namespace NongDanService.Services
{
    public interface ILoNongSanService
    {
        List<LoNongSanDTO> GetAll();
        List<LoNongSanDTO> GetByTrangTrai(int maTrangTrai);
        List<LoNongSanDTO> GetByNongDan(int maNongDan);
        LoNongSanDTO? GetById(int id);
        LoNongSanDTO? GetByQRCode(string maQR);
        List<LoNongSanDTO> GetByTrangThai(string trangThai);
        int Create(LoNongSanCreateDTO dto);
        bool Update(int id, LoNongSanUpdateDTO dto);
        bool UpdateSoLuong(int id, decimal soLuongMoi);
        bool Delete(int id);
    }
}