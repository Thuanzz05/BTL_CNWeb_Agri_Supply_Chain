using NongDanService.Data;
using NongDanService.Models.DTOs;

namespace NongDanService.Services
{
    public class LoNongSanService : ILoNongSanService
    {
        private readonly ILoNongSanRepository _repo;

        public LoNongSanService(ILoNongSanRepository repo)
        {
            _repo = repo;
        }

        public List<LoNongSanDTO> GetAll() => _repo.GetAll();

        public List<LoNongSanDTO> GetByTrangTrai(int maTrangTrai) => _repo.GetByTrangTrai(maTrangTrai);

        public List<LoNongSanDTO> GetByNongDan(int maNongDan) => _repo.GetByNongDan(maNongDan);

        public LoNongSanDTO? GetById(int id) => _repo.GetById(id);

        public LoNongSanDTO? GetByQRCode(string maQR) => _repo.GetByQRCode(maQR);

        public List<LoNongSanDTO> GetByTrangThai(string trangThai) => _repo.GetByTrangThai(trangThai);

        public int Create(LoNongSanCreateDTO dto) => _repo.Create(dto);

        public bool Update(int id, LoNongSanUpdateDTO dto) => _repo.Update(id, dto);

        public bool Delete(int id) => _repo.Delete(id);
    }
}