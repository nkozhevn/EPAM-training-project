using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillActivator : MonoBehaviour
{
    [SerializeField] private List<Skill> skills;

    private List<Skill> _pickedSkills =>
        skills.Where(x => x.IsPicked).ToList();

    private void Update()
    {
        for (int i = 0; i < _pickedSkills.Count; i++)
        {
            if (Input.GetButtonDown(_pickedSkills[i].buttonKeyCode))
            {
                _pickedSkills[i].Activate();
            }
        }
    }

    public void AddSkillByName(string name)
    {
        var skill = skills.First(x => x.InventoryItem.Name == name);
        skill.IsPicked = true;
    }
}
