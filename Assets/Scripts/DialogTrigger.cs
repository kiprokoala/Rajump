using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public bool isInRange;
    public Animator animator;

    public Text nameUI;
    public Text textUI;

    public string creatureName = "Vampire";

    public GameObject zombie;

    public static DialogTrigger instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if ((isInRange && Input.GetKeyDown(KeyCode.I)) || (isInRange && tag == "Reaper"))
        {
            PlayerMovement.instance.enabled = false;
            PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
            PlayerMovement.instance.rb.velocity = Vector3.zero;
            PlayerMovement.instance.animator.SetFloat("Speed", 0);
            animator.SetBool("buttonPressed", false);
            animator.SetBool("enterDialog", true);
            StartDialog();
        }
    }

    void StartDialog()
    {
        string text = "";
        string the_name = "";
        switch (creatureName) {
            case "Vampire":
                the_name = "Vampire";
                text = "My allies are strong, but with my blood, you will be faster than ever!";
                break;
            case "Witch":
                the_name = "Witch";
                text = "My allies are unkillable, but with my potions, you will be unbeatable!";
                break;
            case "Crystal":
                the_name = "Crystal";
                text = "I can give you more zombies in exchange of some money...";
                break;
        }
        nameUI.text = the_name;
        StopAllCoroutines();
        StartCoroutine(typeDialog(text));
    }

    public void CloseDialog()
    {
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        animator.SetBool("buttonPressed", true);
        animator.SetBool("enterDialog", false);
    }

    public void yesClick()
    {

        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        animator.SetBool("buttonPressed", true);
        animator.SetBool("enterDialog", false);
        if (creatureName != "Crystal")
        {
            StartCoroutine(changeScene());
        }else if (SceneManager.GetActiveScene().name == "Level02")
        {
            Inventory.instance.coinsCount -= 20;
            Inventory.instance.UpdateTextUI();
            GameObject zombiie = Instantiate(zombie, new Vector3(143.7f,15f,0), Quaternion.identity);
            zombiie.transform.GetChild(2).position = new Vector3(zombiie.transform.position.x + 2, zombiie.transform.GetChild(2).position.y, 0);
        }
        else
        {
            Inventory.instance.coinsCount -= 20;
            Inventory.instance.UpdateTextUI();
            GameObject zombiie = Instantiate(zombie, new Vector3(73f, 70f, 0), Quaternion.identity);
            zombiie.transform.GetChild(2).position = new Vector3(zombiie.transform.position.x + 1, zombiie.transform.GetChild(2).position.y, 0);
        }
    }
    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator typeDialog(string text)
    {
        textUI.text = "";
        foreach (char charac in text)
        {
            textUI.text += charac;
            yield return new WaitForSeconds(0.025f);
        }
    }
}
