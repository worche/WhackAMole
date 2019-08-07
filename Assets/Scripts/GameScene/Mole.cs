using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float speed;
    float downPos = 0f;
    float highPos = 15f;

    int MoleHealth = 1; // başlangıçta sahip olunan can 

    public int moleHealth
    {
        get
        {
            return MoleHealth;
        }
        set
        {
            if (value <= 0)
            {
                Hide();//can sıfırn altına düştüğü zaman 
            }
            else //can sıfırdan büyükse canı bir düşür yukarda kalma süresine 1 saniye ekle
            {
                animator.SetBool("hide", true);
                DownTime += 1f; // 
                MoleHealth -= value;
                
            }

        }
    }


    public bool isShow = false;

    AudioSource audioSource;

    public AudioClip showSound;
    public AudioClip hideSound;

    Animator animator;

    float DownTime = 2f;
    public float downTime
    {
        get
        {
            return DownTime;
        }
        set
        {
            if (value <= 0)//belli bir süre vurulmazsa GameManager da bulunan health değerini bir azaltıyor.
            {

                audioSource.PlayOneShot(hideSound);
                Hide();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().health--;//ve mole bir hit alıyor

            }
            else
            {
                DownTime = value;
            }
        }
    }

    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.GetChild(0).transform.localPosition;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //sürekli pozisyonunu hedef pozisyona lerp kullanarak yumuşak biçimde yaklaştırıyor. bu sayede sadece targetPos değerini herhangi bir fonksiyonda 
        transform.GetChild(0).transform.localPosition = Vector3.Lerp(transform.GetChild(0).transform.localPosition, targetPos, Time.deltaTime * speed * 10);
        //değiştirmemiz objenin konumunu yumuşak şekilde değiştirecektir. 
        //objenin kendisi yerine child objesine göre hareket sağlıyorum. Bu sayede karakteri oyun alannında istediğim rotationda döndürebiliyorum.

        if (isShow)
        {
            downTime -= Time.deltaTime; //vurulmadan geçen süre hesabı
        }
    }

    public void Show(float _speed)
    {
        speed = _speed;
        targetPos.y = highPos;
        isShow = true;
        audioSource.PlayOneShot(showSound);
    }

    public void Hide()
    {

        targetPos.y = downPos;
        DownTime = 2f;
        isShow = false;
        animator.SetBool("hide", true);
    }

    public void SetMoleHealth(int health)
    {
        MoleHealth = health;
    }
}
