# 💻 CSharp_Kurs

## 🧠 Umumy Mazmuny
Bu repository — **C# okuwlary** üçin taýýarlanylan ähli kodlary, mysallary we düşündirişleri öz içine alýar.  
Her bir tema, **başlangyçdan orta derejä çenli** C# düşünjelerini mysallar arkaly görkeziler.

---

## 📘 Düzgünler we Talaplar

🔹 **Kodlaryň hemmesi ýazylmaly** — sapak boýunça görkezilen ähli mysallar doly ýerine ýetirilmeli.  
🔹 Her bir kod blokunda **comment bölegi** bolmaly — kodyň näme edýändigini düşündirýän gysga düşündiriş goşmaly.  
🔹 Her bölüm **Console-da işletmeli** we netijesi barlanylmaly.  
🔹 Geçen sapakdaky mysallaryň **kemçilikleri çözülmeli** we täzeden dogry görnüşde ýazylmaly.  
🔹 Kod stili arassa, düşündirişler düşnükli bolmaly.

---

## 🧩 Mysal Üstünde Iş
> “Geçen sapakdaky mysalyň kemçiliklerini çözmeli.”  
> Bu ýerde öňki sapakdaky kod analiz edilip, näsaz ýerleri düzedilip, dogry logika bilen gaýtadan ýazylmaly.

---

## ⚙️ Git Ulgamy boýunça Gollanma

Eger repository-de başga işgärler hem `master` dalyna kod ugradýan bolsa, aşakdaky ädimleri ulan:

```bash
git fetch origin
git rebase origin/master
# gerek bolsa konfliktleri çözüp:
git add .
git rebase --continue
git push origin master --force-with-lease
