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
> "Geçen sapakdaky mysalyň kemçiliklerini çözmeli."  
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
```


---
## 🧠 Ders 4 – OOP (Object Oriented Programming) — 2

Bu sapakda Obýekt Ugrundaky Programmirleme (OOP) düşünjesiniň dowamyny öwrenýäris.
C# dilinde abstrakt synyplar, virtual / override / sealed methodlar, interfeysler, we pattern matching ýaly möhüm konseptler bilen işleýäris.


Bu sapakda OOP (Object Oriented Programming) düşünjesiniň ileri derejeleri öwrenilýär.
abstract, virtual, override, we sealed kimi aýratynlyklar bilen miras alyş gatnaşyklary görkezilýär.
KargoHasaplama bazasyndan StandartKargo we TizKargo ýaly klasslar döredilip bahanyň hasaplanşy görkezilýär.
interface arkaly dürli nalok (salgyt) syýasatlary (Nalok10, Nalok20) ýerine ýetirilýär.
Ahyrynda SozlemKomekcileri statik klassa arkaly setirler bilen işlemek we IJsonYAzdyr interfeýsi arkaly JSON formatda ýazdyrmak görkezilýär.
```csharp 