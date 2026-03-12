using NongDanService.Models.DTOs;

namespace NongDanService.Data
{
    public interface ITrangTraiRepository
    {
        List<TrangTraiDTO> GetAll();
        List<TrangTraiDTO> GetByNongDan(int maNongDan);
        TrangTraiDTO? GetById(int id);
        int Create(TrangTraiCreateDTO dto);
        bool Update(int id, TrangTraiUpdateDTO dto);
        bool Delete(int id);
    }
}