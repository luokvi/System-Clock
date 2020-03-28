Tämän ohjelman tarkoitus on hakea käyttäjän systeemin
aika ja näyttää se reaaliajassa sekä analogisessa että
digitaalisessa kellotaulussa.

Rivillä 4 lisätään käyttöön UnityEnginen UI-namespace, jotta voidaan
käyttää Unityn UI-työkalua, jolla on päätetty toteuttaa digitaalinen
kello pelimoottorissa.

Rivillä 5 lisätään System-namespace käyttöön, jotta saadaan
käyttäjän systeemistä kellonaika.

Riveillä 10-13 luodaan referenssit tekstielementtiin joka esittää
digitaalista kelloa (digitalClock), ja niiden GameObjectien transformit,
jotka esittävät analogisen kellon viisareita (secondsHand, minutesHand ja
hoursHand). Referenssi transformiin, eikä GameObjectiin, riittää tässä,
sillä vain objektien rotaatiota halutaan hallita ohjelmalla.

Update-funktiossa haetaan systeemin nykyinen aika ja tallenetaan se
muuttujaan time. Update-funktio ajetaan jokaisella ruudulla, eli
tyypillisesti useita kertoja sekunnissa, joten saadaan varmasti
reaaliaikaisesti tietoa nykyisestä ajasta.

updateAnalog-funktiossa päivitetään analogista kelloa vastaavat
grafiikat näyttämään oikeaa aikaa. Time-muuttujasta saadaan erikseen
sekunnit, minuutit ja tunnit.
Sekunti (second) saa arvoja väliltä 0-59, ja sekuntiviisarin (secondsHand)
rotaation tulisi olla vastaavasti asteluku väliltä 0-359. Muutetaan sekunnit
tarvittavaksi rotaatioksi kertomalla se 6:lla. Jotta viisari liikkuisi
myötäpäivään pitää rotaation olla negatiivinen, joten kerrotaan -6:lla.
Syötetään saatu rotaatio secondsHand-transformille Quaternion.Euler()-metodin
kautta, jotta transform pystyy käsittelemään sen oikein. Haluttu
rotaatio-akseli on z, joten x- ja y- akselit voidaan pitää nollina.
Minuuttiviisarin kanssa tehdäään samoin.
Tunti (hour) saa arvoja väliltä 1-12, joten se kerrotaan -30:lla, jotta
saadaan oikea rotaatio.

updateDigital-funktiossa päivitetään digitaalista kelloa vastaava UI-elementti
näyttämään oikeaa aikaa. Muutetaan time-muuttuja DateTime-oliosta tekstiksi
toString()-metodilla, joka on muotoa hh.mm.ss ja tunnit 24-tunnin muodossa
(siksi HH isolla). Muutetaan digitalClock -tekstielementin sisäinen teksti
saaduksi teksiksi.