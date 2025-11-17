using System.ComponentModel.DataAnnotations;

namespace QRRestaurantApp.Backend.Entities
{
    public class TableSessionLog
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public string Code { get; set; }
        public string DeviceId { get; set; } = string.Empty;  // 🔹 her cihaz için benzersiz

        //Oturum başlangıç zamanı (QR okutulduğu an)
        public DateTime SessionStart { get; set; } = DateTime.UtcNow;
        
        //Oturum bitiş zamanı (token süresi dolduğunda, çıkış yapıldığında)
        public DateTime? SessionEnd { get; set; }

        //Oturum süresince sipariş verilip verilmediğini gösterir
        public bool HasOrder { get; set; }

        //Son aktivite (QR okuttuğu an, sipariş verdiği an, yorum bıraktığı an)
        public DateTime LastActivty { get; set; }

        // 🔹 Kullanıcı manuel çıkış yaptıysa veya sistem tarafından sonlandırıldıysa açıklama
        public string? EndReason { get; set; }

        // 🔹 İsteğe bağlı: IP adresi veya device info (UI için)
        public string? DeviceInfo { get; set; }
    }

}
