using NongDanService.Models.DTOs;

namespace NongDanService.Services
{
    public interface ITrangTraiService
    {
        List<TrangTraiDTO> GetAll();
        List<TrangTraiDTO> GetByNongDan(int maNongDan);
        TrangTraiDTO? GetById(int id);
        int Create(TrangTraiCreateDTO dto);
        bool Update(int id, TrangTraiUpdateDTO dto);
        bool Delete(int id);
    }
}