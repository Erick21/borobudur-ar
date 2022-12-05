using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Handler3D : MonoBehaviour
{
    [SerializeField] GameObject _item1, _item2, _item3, _item4, _item5, _item6, _item7, _item8;
    [SerializeField] GameObject _arrowUp, _arrowDown, _barDescription, _barInfo;
    [SerializeField] TMP_Text _textDescription;
    [SerializeField] GameObject _model1, _model2, _model3, _model4, _model5, _model6, _model7, _model8;

    const string model1Desc = "Borobudur dibangun sebagai tempat ziarah spiritual, yakni sarana untuk menunutun umat manusia beralih dari nafsu duniawi menujuk kebajikan dan pencerahan Dharma. Candi berdenah mandala, berbentuk Gunung, dan bermahkota stupa ini merupakan mahakarya, agung leluhur bangsa Indonesia. Kemegahan, keindahan, dan kejeniusan rancang bangun Borobudur merupakan bukti betapa tingginya seni, budaya, ekonomi dan teknologi peradaban Jawa kuno.\n\nBorobudur adalah lambang kehebatan wangsa Sailendra yang berkuasa di Jawa Tengah antara akhir abad VIII dan abad IX.Menurut sejarawan candi ini dibangun pada masa Maharaja Samaratunggadan dilanjutkan oleh putrinya Ratu Pramuwardhani.Perencanaan dan warisan priyayi Borobudur mungkin sudah dimulai oleh pendahulunya yaitu Raja Dharanindra (782-792) dan Raja Samawaragrawijaya(792-835).\n\nTubuh Borobudur sesusngguhnya adalah susunan cangkang batu setebal hanya beberapa meter yang membungkus bukit alami.Sebelum dipugar pemerintah Indonesia dengan bantuan UNESCO pada tahun 1973-1985, rembesan air hujan dalam tubuh candi serta kemiringan struktur bangunan hampir saja meruntuhkan monumen ini.";
    const string model2Desc = "Bagian Barat dari Stupa Terbuka yang merupakan 1 dari 5 Golongan Mudra.\n\nBagian Barat mempunyai arti Semadi atau Meditasi";
    const string model3Desc = "Bagian Selatan dari Stupa Terbuka yang merupakan 1 dari 5 Golongan Mudra.\n\nBagian Selatan mempunyai arti Kedermawanan";
    const string model4Desc = "Bagian Tengah dari Stupa Terbuka yang merupakan 1 dari 5 Golongan Mudra.\n\nBagian Tengah mempunyai arti Akal Budi";
    const string model5Desc = "Bagian Timur dari Stupa Terbuka yang merupakan 1 dari 5 Golongan Mudra.\n\nBagian Timur mempunyai arti Memanggil bumi sebagai saksi";
    const string model6Desc = "Bagian Utara dari Stupa Terbuka yang merupakan 1 dari 5 Golongan Mudra.\n\nBagian Utara mempunyai arti Ketidakgentaran";
    const string model7Desc = "Dari sekian banyak patung, hanya dua di antaranya yang berada dalam stupa terbuka. Satu di antaranya terlihat hanya sebagian kepalanya, yang lain kelihatan utuh. Selain wujud buddha dalam kosmologi buddhis yang terukir di dinding, di Borobudur terdapat banyak arca buddha duduk bersila dalam posisi teratai serta menampilkan mudra atau sikap tangan simbolis tertentu.";
    const string model8Desc = "Puncak Borobudur dimahkotai oleh stupa besar tertutup yang dibangun di atas dua kuntum teratai yang sedang mekar. Dinding-dinding yang terdapat pada tingkat berbentuk persegi dihiasi ukiran yang indah menggambarkan kisah kehidupan, reinkarnasi dan pencapaian akhir tentang kebenaran ajaran Budha, ditambah dengan ratusan gambar Budha dalam berbagai perwujudannya yang menghiasi dinding-dinding. Tingkatan lingkaran yang paling atas melambangkan keabadian dan keadaan tanpa awal dan akhir.\n\nDilansir dari situs Kabupaten Magelang, stupa dalam budaya agama Buddha didirikan untuk menyimpan relik Buddha atau relik para siswa yang telah mencapai kesucian. Dalam bahasa agama, relik disebut saririka dhatu, diambil dari sisa jasmani yang berupa kristal setelah dilaksanakan kremasi.Bila belum mencapai kesucian, sisa jasmani tidak berbentuk kristal dan tidak diambil. Diyakini bahwa relik ini mempunyai getaran suci yang mengarahkan pada perbuatan baik.";

    public void ChangeItem(int no)
    {
        _item1.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item2.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item3.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item4.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item5.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item6.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item7.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item8.transform.Find("Image-Yes").gameObject.SetActive(false);

        _model1.SetActive(false);
        _model2.SetActive(false);
        _model3.SetActive(false);
        _model4.SetActive(false);
        _model5.SetActive(false);
        _model6.SetActive(false);
        _model7.SetActive(false);
        _model8.SetActive(false);

        GameObject selectedItem = null, selectedModel = null;
        string desc = "";
        switch (no)
        {
            case 1:
                selectedItem = _item1;
                selectedModel = _model1;
                desc = model1Desc;
                break;
            case 2:
                selectedItem = _item2;
                selectedModel = _model2;
                desc = model2Desc;
                break;
            case 3:
                selectedItem = _item3;
                selectedModel = _model3;
                desc = model3Desc;
                break;
            case 4:
                selectedItem = _item4;
                selectedModel = _model4;
                desc = model4Desc;
                break;
            case 5:
                selectedItem = _item5;
                selectedModel = _model5;
                desc = model5Desc;
                break;
            case 6:
                selectedItem = _item6;
                selectedModel = _model6;
                desc = model6Desc;
                break;
            case 7:
                selectedItem = _item7;
                selectedModel = _model7;
                desc = model7Desc;
                break;
            case 8:
                selectedItem = _item8;
                selectedModel = _model8;
                desc = model8Desc;
                break;
        }

        selectedItem.transform.Find("Image-Yes").gameObject.SetActive(true);
        selectedModel.SetActive(true);

        _arrowUp.SetActive(false);
        _arrowDown.SetActive(true);
        _barDescription.SetActive(true);
        _textDescription.text = desc;
    }

    public void ShowDescription(bool active)
    {
        _arrowUp.SetActive(!active);
        _arrowDown.SetActive(active);
        _barDescription.SetActive(active);
    }

    public void ShowInfo(bool active)
    {
        _barInfo.SetActive(active);
    }

    public void GoToARMode()
    {
        SceneManager.LoadScene("AR");
    }
}