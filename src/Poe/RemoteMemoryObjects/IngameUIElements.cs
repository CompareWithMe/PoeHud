using System;
using System.Collections.Generic;
using PoeHUD.Poe.Elements;
using PoeHUD.Poe.UI;
using PoeHUD.Poe.UI.Elements;

namespace PoeHUD.Poe.RemoteMemoryObjects
{
    public class IngameUIElements : RemoteMemoryObject
    {
        public Element HpGlobe
        {
            get { return ReadObjectAt<Element>(0x40); }
        }

        public Element ManaGlobe
        {
            get { return ReadObjectAt<Element>(0x44); }
        }

        public Element Flasks
        {
            get { return ReadObjectAt<Element>(0x4C); }
        }

        public Element XpBar
        {
            get { return ReadObjectAt<Element>(0x50); }
        }

        public Element MenuButton
        {
            get { return ReadObjectAt<Element>(0x54); }
        }

        public Element ShopButton
        {
            get { return ReadObjectAt<Element>(4 + 0x7C); }
        }

        public Element HideoutEditButton
        {
            get { return ReadObjectAt<Element>(0x84); }
        }

        public Element HideoutStashButton
        {
            get { return ReadObjectAt<Element>(0x88); }
        }

        public Element Mouseposition
        {
            get { return ReadObjectAt<Element>(0xA0); }
        }

        public Element ActionButtons
        {
            get { return ReadObjectAt<Element>(0xA4); }
        }

        public Element Chat
        {
            get { return ReadObjectAt<Element>(12 + 0xD8); }
        }

        public Element QuestTracker
        {
            get { return ReadObjectAt<Element>(4 + 0xE8); }
        }

        public Element MtxInventory
        {
            get { return ReadObjectAt<Element>(4 + 0xEC); }
        }

        public Element MtxShop
        {
            get { return ReadObjectAt<Element>(4 + 0xF0); }
        }

               public Element InventoryPanel
         {
-            get { return ReadObjectAt<Element>(12 + 0xF4); }
+            get { return ReadObjectAt<Element>(12 + 0xF8); }
         }
 
         public Element StashPanel
@@ -95,7 +95,7 @@ public Element SocialPanel
 
         public Element TreePanel
         {
-            get { return ReadObjectAt<Element>(12 + 0x108); }
+            get { return ReadObjectAt<Element>(12 + 0x10C); }
         }
 
         public Element CharacterPanel
@@ -120,14 +120,14 @@ public Element WorldPanel
 
         public Map Map
         {
-            get { return ReadObjectAt<Map>(16 + 0x11C); }
+            get { return ReadObjectAt<Map>(16 + 0x120); }
         }
 
         public IEnumerable<ItemsOnGroundLabelElement> ItemsOnGroundLabels
         {
             get
             {
-                var itemsOnGroundLabelRoot = ReadObjectAt<ItemsOnGroundLabelElement>(16 + 0x120);
+                var itemsOnGroundLabelRoot = ReadObjectAt<ItemsOnGroundLabelElement>(16 + 0x124);
                 return itemsOnGroundLabelRoot.Children;
             }
         }
@@ -153,12 +153,12 @@ public Element Buffs2
 
         public Element OpenLeftPanel
         {
-            get { return ReadObjectAt<Element>(16 + 0x154); }
+            get { return ReadObjectAt<Element>(16 + 0x158); }
         }
 
         public Element OpenRightPanel
         {
-            get { return ReadObjectAt<Element>(16 + 0x158); }
+            get { return ReadObjectAt<Element>(16 + 0x15c); }
         }
 
         public Element OpenNpcDialogPanel
@@ -189,12 +189,12 @@ public Element SwitchingZoneInfo
 
         public Element GemLvlUpPanel
         {
-            get { return ReadObjectAt<Element>(20 + 0x1F8); }
+            get { return ReadObjectAt<Element>(20 + 0x1FC); }
         }
 
         public ItemOnGroundTooltip ItemOnGroundTooltip
         {
-            get { return ReadObjectAt<ItemOnGroundTooltip>(20 + 0x208); }
+            get { return ReadObjectAt<ItemOnGroundTooltip>(20 + 0x20C); }
         }
     }
 }
\ No newline at end of file
