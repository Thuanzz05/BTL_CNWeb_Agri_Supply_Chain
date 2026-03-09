using System;
using System.Collections.Generic;

namespace NongDanService.Models;

public partial class TonKho
{
    public int MaKho { get; set; }

    public int MaLo { get; set; }

    public decimal SoLuong { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual Kho MaKhoNavigation { get; set; } = null!;

    public virtual LoNongSan MaLoNavigation { get; set; } = null!;
}
