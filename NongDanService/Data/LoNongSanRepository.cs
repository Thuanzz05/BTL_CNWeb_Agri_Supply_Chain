using Microsoft.Data.SqlClient;
using NongDanService.Models.DTOs;
using System.Data;

namespace NongDanService.Data
{
    public class LoNongSanRepository : ILoNongSanRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<LoNongSanRepository> _logger;

        public LoNongSanRepository(IConfiguration config, ILogger<LoNongSanRepository> logger)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
            _logger = logger;
        }

        public List<LoNongSanDTO> GetAll()
        {
            var list = new List<LoNongSanDTO>();
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(@"
                    SELECT ln.MaLo, ln.MaTrangTrai, ln.MaSanPham, ln.SoLuongBanDau, ln.SoLuongHienTai,
                           ln.NgayThuHoach, ln.HanSuDung, ln.MaQR, ln.TrangThai, ln.NgayTao,
                           tt.TenTrangTrai, sp.TenSanPham, sp.DonViTinh
                    FROM LoNongSan ln
                    LEFT JOIN TrangTrai tt ON ln.MaTrangTrai = tt.MaTrangTrai
                    LEFT JOIN SanPham sp ON ln.MaSanPham = sp.MaSanPham
                    ORDER BY ln.NgayTao DESC", conn);

                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(MapToDTO(reader));
                }
                _logger.LogInformation("Retrieved {Count} crop lots from database", list.Count);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error occurred while getting all crop lots");
                throw new Exception("Lỗi truy vấn cơ sở dữ liệu", ex);
            }
            return list;
        }

        public List<LoNongSanDTO> GetByTrangTrai(int maTrangTrai)
        {
            var list = new List<LoNongSanDTO>();
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(@"
                    SELECT ln.MaLo, ln.MaTrangTrai, ln.MaSanPham, ln.SoLuongBanDau, ln.SoLuongHienTai,
                           ln.NgayThuHoach, ln.HanSuDung, ln.MaQR, ln.TrangThai, ln.NgayTao,
                           tt.TenTrangTrai, sp.TenSanPham, sp.DonViTinh
                    FROM LoNongSan ln
                    LEFT JOIN TrangTrai tt ON ln.MaTrangTrai = tt.MaTrangTrai
                    LEFT JOIN SanPham sp ON ln.MaSanPham = sp.MaSanPham
                    WHERE ln.MaTrangTrai = @MaTrangTrai
                    ORDER BY ln.NgayTao DESC", conn);
                
                cmd.Parameters.AddWithValue("@MaTrangTrai", maTrangTrai);

                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(MapToDTO(reader));
                }
                _logger.LogInformation("Retrieved {Count} crop lots for farm {FarmId}", list.Count, maTrangTrai);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error occurred while getting crop lots for farm {FarmId}", maTrangTrai);
                throw new Exception("Lỗi truy vấn cơ sở dữ liệu", ex);
            }
            return list;
        }

        public List<LoNongSanDTO> GetByNongDan(int maNongDan)
        {
            var list = new List<LoNongSanDTO>();
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(@"
                    SELECT ln.MaLo, ln.MaTrangTrai, ln.MaSanPham, ln.SoLuongBanDau, ln.SoLuongHienTai,
                           ln.NgayThuHoach, ln.HanSuDung, ln.MaQR, ln.TrangThai, ln.NgayTao,
                           tt.TenTrangTrai, sp.TenSanPham, sp.DonViTinh
                    FROM LoNongSan ln
                    LEFT JOIN TrangTrai tt ON ln.MaTrangTrai = tt.MaTrangTrai
                    LEFT JOIN SanPham sp ON ln.MaSanPham = sp.MaSanPham
                    WHERE tt.MaNongDan = @MaNongDan
                    ORDER BY ln.NgayTao DESC", conn);
                
                cmd.Parameters.AddWithValue("@MaNongDan", maNongDan);

                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(MapToDTO(reader));
                }
                _logger.LogInformation("Retrieved {Count} crop lots for farmer {FarmerId}", list.Count, maNongDan);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error occurred while getting crop lots for farmer {FarmerId}", maNongDan);
                throw new Exception("Lỗi truy vấn cơ sở dữ liệu", ex);
            }
            return list;
        }

        public LoNongSanDTO? GetById(int id)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(@"
                    SELECT ln.MaLo, ln.MaTrangTrai, ln.MaSanPham, ln.SoLuongBanDau, ln.SoLuongHienTai,
                           ln.NgayThuHoach, ln.HanSuDung, ln.MaQR, ln.TrangThai, ln.NgayTao,
                           tt.TenTrangTrai, sp.TenSanPham, sp.DonViTinh
                    FROM LoNongSan ln
                    LEFT JOIN TrangTrai tt ON ln.MaTrangTrai = tt.MaTrangTrai
                    LEFT JOIN SanPham sp ON ln.MaSanPham = sp.MaSanPham
                    WHERE ln.MaLo = @MaLo", conn);
                
                cmd.Parameters.AddWithValue("@MaLo", id);

                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    _logger.LogWarning("Crop lot with ID {LotId} not found", id);
                    return null;
                }
                return MapToDTO(reader);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error occurred while getting crop lot with ID {LotId}", id);
                throw new Exception("Lỗi truy vấn cơ sở dữ liệu", ex);
            }
        }

        public LoNongSanDTO? GetByQRCode(string maQR)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(@"
                    SELECT ln.MaLo, ln.MaTrangTrai, ln.MaSanPham, ln.SoLuongBanDau, ln.SoLuongHienTai,
                           ln.NgayThuHoach, ln.HanSuDung, ln.MaQR, ln.TrangThai, ln.NgayTao,
                           tt.TenTrangTrai, sp.TenSanPham, sp.DonViTinh
                    FROM LoNongSan ln
                    LEFT JOIN TrangTrai tt ON ln.MaTrangTrai = tt.MaTrangTrai
                    LEFT JOIN SanPham sp ON ln.MaSanPham = sp.MaSanPham
                    WHERE ln.MaQR = @MaQR", conn);
                
                cmd.Parameters.AddWithValue("@MaQR", maQR);

                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    _logger.LogWarning("Crop lot with QR code {QRCode} not found", maQR);
                    return null;
                }
                return MapToDTO(reader);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error occurred while getting crop lot with QR code {QRCode}", maQR);
                throw new Exception("Lỗi truy vấn cơ sở dữ liệu", ex);
            }
        }

        public List<LoNongSanDTO> GetByTrangThai(string trangThai)
        {
            var list = new List<LoNongSanDTO>();
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(@"
                    SELECT ln.MaLo, ln.MaTrangTrai, ln.MaSanPham, ln.SoLuongBanDau, ln.SoLuongHienTai,
                           ln.NgayThuHoach, ln.HanSuDung, ln.MaQR, ln.TrangThai, ln.NgayTao,
                           tt.TenTrangTrai, sp.TenSanPham, sp.DonViTinh
                    FROM LoNongSan ln
                    LEFT JOIN TrangTrai tt ON ln.MaTrangTrai = tt.MaTrangTrai
                    LEFT JOIN SanPham sp ON ln.MaSanPham = sp.MaSanPham
                    WHERE ln.TrangThai = @TrangThai
                    ORDER BY ln.NgayTao DESC", conn);
                
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(MapToDTO(reader));
                }
                _logger.LogInformation("Retrieved {Count} crop lots with status {Status}", list.Count, trangThai);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error occurred while getting crop lots with status {Status}", trangThai);
                throw new Exception("Lỗi truy vấn cơ sở dữ liệu", ex);
            }
            return list;
        }

        public int Create(LoNongSanCreateDTO dto)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                
                // Tạo mã QR tự động nếu không có
                var maQR = dto.MaQR ?? $"QR_{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString("N")[..8]}";
                
                using var cmd = new SqlCommand(@"
                    INSERT INTO LoNongSan (MaTrangTrai, MaSanPham, SoLuongBanDau, SoLuongHienTai, 
                                          NgayThuHoach, HanSuDung, MaQR, TrangThai, NgayTao) 
                    OUTPUT INSERTED.MaLo 
                    VALUES (@MaTrangTrai, @MaSanPham, @SoLuongBanDau, @SoLuongHienTai, 
                            @NgayThuHoach, @HanSuDung, @MaQR, @TrangThai, @NgayTao)", conn);

                cmd.Parameters.AddWithValue("@MaTrangTrai", dto.MaTrangTrai);
                cmd.Parameters.AddWithValue("@MaSanPham", dto.MaSanPham);
                cmd.Parameters.AddWithValue("@SoLuongBanDau", dto.SoLuongBanDau);
                cmd.Parameters.AddWithValue("@SoLuongHienTai", dto.SoLuongBanDau); // Ban đầu = hiện tại
                cmd.Parameters.AddWithValue("@NgayThuHoach", dto.NgayThuHoach);
                cmd.Parameters.AddWithValue("@HanSuDung", dto.HanSuDung);
                cmd.Parameters.AddWithValue("@MaQR", maQR);
                cmd.Parameters.AddWithValue("@TrangThai", "san_sang");
                cmd.Parameters.AddWithValue("@NgayTao", DateTime.Now);

                conn.Open();
                var maLo = (int)cmd.ExecuteScalar();
                
                _logger.LogInformation("Created new crop lot with ID {LotId}", maLo);
                return maLo;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error occurred while creating crop lot");
                if (ex.Number == 547) // Foreign key constraint
                    throw new Exception("Trang trại hoặc sản phẩm không tồn tại trong hệ thống", ex);
                if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint
                    throw new Exception("Mã QR đã tồn tại trong hệ thống", ex);
                throw new Exception("Lỗi tạo lô nông sản trong cơ sở dữ liệu: " + ex.Message, ex);
            }
        }

        public bool Update(int id, LoNongSanUpdateDTO dto)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                var setParts = new List<string>();
                var cmd = new SqlCommand();
                cmd.Connection = conn;

                if (dto.SoLuongHienTai.HasValue)
                {
                    setParts.Add("SoLuongHienTai = @SoLuongHienTai");
                    cmd.Parameters.AddWithValue("@SoLuongHienTai", dto.SoLuongHienTai.Value);
                }

                if (dto.NgayThuHoach.HasValue)
                {
                    setParts.Add("NgayThuHoach = @NgayThuHoach");
                    cmd.Parameters.AddWithValue("@NgayThuHoach", dto.NgayThuHoach.Value);
                }

                if (dto.HanSuDung.HasValue)
                {
                    setParts.Add("HanSuDung = @HanSuDung");
                    cmd.Parameters.AddWithValue("@HanSuDung", dto.HanSuDung.Value);
                }

                if (!string.IsNullOrEmpty(dto.MaQR))
                {
                    setParts.Add("MaQR = @MaQR");
                    cmd.Parameters.AddWithValue("@MaQR", dto.MaQR);
                }

                if (!string.IsNullOrEmpty(dto.TrangThai))
                {
                    setParts.Add("TrangThai = @TrangThai");
                    cmd.Parameters.AddWithValue("@TrangThai", dto.TrangThai);
                }

                if (setParts.Count == 0)
                {
                    return false; // Không có gì để cập nhật
                }

                cmd.CommandText = $"UPDATE LoNongSan SET {string.Join(", ", setParts)} WHERE MaLo = @MaLo";
                cmd.Parameters.AddWithValue("@MaLo", id);

                conn.Open();
                var rowsAffected = cmd.ExecuteNonQuery();
                
                if (rowsAffected > 0)
                {
                    _logger.LogInformation("Updated crop lot with ID {LotId}", id);
                    return true;
                }
                
                _logger.LogWarning("No crop lot found with ID {LotId} to update", id);
                return false;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error occurred while updating crop lot with ID {LotId}", id);
                throw new Exception("Lỗi cập nhật lô nông sản trong cơ sở dữ liệu", ex);
            }
        }



        public bool Delete(int id)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand("DELETE FROM LoNongSan WHERE MaLo = @MaLo", conn);
                cmd.Parameters.AddWithValue("@MaLo", id);

                conn.Open();
                var rowsAffected = cmd.ExecuteNonQuery();
                
                if (rowsAffected > 0)
                {
                    _logger.LogInformation("Deleted crop lot with ID {LotId}", id);
                    return true;
                }
                
                _logger.LogWarning("No crop lot found with ID {LotId} to delete", id);
                return false;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error occurred while deleting crop lot with ID {LotId}", id);
                if (ex.Number == 547)
                    throw new Exception("Không thể xóa lô nông sản này vì đang có dữ liệu liên quan", ex);
                throw new Exception("Lỗi xóa lô nông sản trong cơ sở dữ liệu", ex);
            }
        }

        private static LoNongSanDTO MapToDTO(SqlDataReader reader)
        {
            return new LoNongSanDTO
            {
                MaLo = reader.GetInt32("MaLo"),
                MaTrangTrai = reader.GetInt32("MaTrangTrai"),
                MaSanPham = reader.GetInt32("MaSanPham"),
                SoLuongBanDau = reader.GetDecimal("SoLuongBanDau"),
                SoLuongHienTai = reader.GetDecimal("SoLuongHienTai"),
                NgayThuHoach = reader.IsDBNull("NgayThuHoach") ? null : reader.GetDateTime("NgayThuHoach"),
                HanSuDung = reader.IsDBNull("HanSuDung") ? null : reader.GetDateTime("HanSuDung"),
                MaQR = reader.IsDBNull("MaQR") ? null : reader.GetString("MaQR"),
                TrangThai = reader.GetString("TrangThai"),
                NgayTao = reader.GetDateTime("NgayTao"),
                TenTrangTrai = reader.IsDBNull("TenTrangTrai") ? null : reader.GetString("TenTrangTrai"),
                TenSanPham = reader.IsDBNull("TenSanPham") ? null : reader.GetString("TenSanPham"),
                DonViTinh = reader.IsDBNull("DonViTinh") ? null : reader.GetString("DonViTinh")
            };
        }
    }
}