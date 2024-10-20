# OtoparkOtomasyon

Projede farklı yetkilere sahip yönetici, üye kullanıcı, misafir kullanıcı olmak üzere 3 kullanıcı tipi vardır.Yönetici hesabına sahip birisi araç girişi, araç çıkışı, araç geçmişi, araç konumları görme gibi fonksiyonları gerçekleştirebilmektedir ayrıca ayarlar menüsünden üye kullanıcı hesaplarını görüntüleme ve silme, tarife ücretlerini güncelleme, profil güncelleme gibi işlemleride gerçekleştirebilir.Üye kullanıcı hesabına sahip birisi sisteme kayıt olduğu plaka no ile araç giriş, çıkış işlemleri bunun yanında kendi aracına ait otopark geçmişini görüntüleyebilir ve profilini güncelleyebilir.Misafir kullanıcı hesabına sahip birisi plaka no ile giriş yapıp araç giriş ve çıkış işlemlerini gerçekleştirebilir.

Proje C# programlama diliyle gerçekleştirilmiştir, veritabanı olarak MS Access kullanılmıştır veritabanı dosyası debug klasörü içinde "otoparkveri.accdb" bulunmaktadır.Proje çalıştırıldığında "Microsoft.ACE.OLEDB.12.0 saglayıcısı yerel makinede kayıtlı değil" hatası alıyorsanız Proje Özelliklerinden > Derleme sekmesinde bulunan 32 bit tercih et seceneğinın işaretini kaldırın.Bu proje Fırat Üniversitesi Nesne Tabanlı Programlama dersi için hazırlanmıştır.

## Proje Ekran Görüntüleri <br>
### Açılış Ekranı
Kullanıcıların hesap bilgileri ile giriş yapmadan önce gelen pencere, programın yüklenmesini temsil ediyor.

![acilis](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/acilis.PNG) <br>

### Kullanıcı Giriş Pencereleri
Kullanıcı türüne göre yönetici, üye ve misafir kullanıcıların hesaplarına erişim sağlamasına yarayan giriş ekranlarını temsil ediyor.

![yonetici_giris](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/yonetici_giris.PNG) <br>
![uye_kaydol](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/uye_kaydol.PNG) <br>
![misafir_giris](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/misafir_giris.PNG) <br>

### Yönetici Anasayfa
Yönetici sisteme kendisine ait kullanıcı adı ve şifre ile giriş yaptığı takdirde yönetici ana menüsü ile karşılaşacaktır.

![anasayfa](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/anasayfa.PNG) <br>

### Araç Giriş
Yönetici otoparka istediği plaka no ile araç girişi yapabilirken, üye ve misafir kullanıcı yalnızca kendilerine ait plaka no ile otoparka araç girişi fonksiyonunu gerçekleştirebilir.

![arac_giris](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/arac_giris.PNG) <br>

### Araç Çıkış
Yönetici otoparktaki tüm araçların çıkışını yapabilirken, üye ve misafir kullanıcı yalnızca kendilerine ait plaka no ile otoparktan araç çıkışı fonksiyonunu gerçekleştirebilir.Bu işlemden sonra bir fatura çıktısı ekranıyla karşılaşılır.

![arac_cikis](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/arac_cikis.png) <br>

### Araç Geçmiş
Yönetici otoparka daha önceden yapılan tüm araç giriş ve çıkış işlemlerine dair geçmişe ulaşabilirken, üye kullanıcı yalnızca kendi aracına ait geçmişi görüntüleyebilir.Misafir kullanıcının bu işleme erişimi yoktur.

![arac_gecmis](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/arac_gecmis.PNG) <br>

### Araç Konumları
Yalnızca yönetici kullanıcı hesabına sahip birisi otoparkın durumunu ve araçların konumlarını görünteleyebilir.

![arac_konum](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/arac_konum.PNG) <br>

### Ayarlar- Kullanıcılar
Yalnızca yönetici kullanıcı hesabına sahip birisi sistemde kayıtlı olan hesapları görüntüleyebilir ve deilediği kullanıcı hesabını silebilir.

![kullanicilar](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/kullanıcılar.PNG) <br>

### Ayarlar- Tarife Ücretleri
Yalnızca yönetici kullanıcı hesabına sahip birisi otoparka ait tarife ücretlerini güncelleme yetkisine sahiptir.

![tarifeler](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/tarifeler.PNG) <br>

### Ayarlar- Profil Bilgi Güncelle
Yönetici ve üye kullanıcı hesabına sahip kişiler profil bilgilerini güncelleyebilir.

![profil_guncelle](https://github.com/regaipaydogdu/OtoparkOtomasyon/blob/master/screenshots/profil_guncelle.PNG) <br>
