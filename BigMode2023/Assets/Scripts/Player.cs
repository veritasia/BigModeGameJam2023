using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static int hp = 4;
    public static int cartridge = 1;
    public static Item[] items = new Item[3];
    public static int amountItems = 0;

    public static int getHP(){
        return hp;
    }

    public static void changeHP(int change){
        hp = hp+=change;
    }

    public static Item[] getItems(){
        return items;
    }

    public static void setItem(Item itemToSet){
        if(amountItems == 3){
            return;
        }else{
            items[amountItems] = itemToSet;
            amountItems++;
        }
    }
}
