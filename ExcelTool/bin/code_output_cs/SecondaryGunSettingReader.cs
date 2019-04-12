using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class SecondaryGunSettingReader{
		private SecondaryGunSetting[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static SecondaryGunSettingReader instance=null;
		public static SecondaryGunSettingReader Instance{
			get{
				if(instance==null){
					instance=new SecondaryGunSettingReader();
					instance.Load();
				}
				return instance;
			}
		}

		void Load(){
			Action<string> onTableLoad=(text)=>{
				string[] lines=text.Split(new string[]{"\r\n"},System.StringSplitOptions.RemoveEmptyEntries);
				int count=lines.Length;
				if(count<0){
					return;
				}
				this.count = count;
				entities=new SecondaryGunSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new SecondaryGunSetting();
					entities[i].ID=int.Parse(vals[0].Trim());
					entities[i].Name=int.Parse(vals[1].Trim());
					entities[i].UnitType=int.Parse(vals[2].Trim());
					entities[i].Speed=float.Parse(vals[3].Trim());
					entities[i].Damage=float.Parse(vals[4].Trim());
					entities[i].Defence=float.Parse(vals[5].Trim());
					entities[i].CoinReward=float.Parse(vals[6].Trim());
					entities[i].CoinPrice=float.Parse(vals[7].Trim());
					entities[i].DefaultLv=int.Parse(vals[8].Trim());
					entities[i].MaxLv=int.Parse(vals[9].Trim());
					entities[i].UnlockType=int.Parse(vals[10].Trim());
					entities[i].UnlockValue=int.Parse(vals[11].Trim());
					entities[i].AtlasName=vals[12];
					entities[i].SpriteName=vals[13];
					entities[i].PrefabName=vals[14];
					entities[i].LocalPos=new Vector3(float.Parse(vals[15].Trim().Split('|')[0]),float.Parse(vals[15].Trim().Split('|')[1]),float.Parse(vals[15].Trim().Split('|')[2]));
					entities[i].PropertyPlus=vals[16];
					entities[i].BulletPrefabName=vals[17];
					entities[i].BulletName=vals[18];
					keyIndexMap[entities[i].ID]=i;
				}
			};

			string fileName=SecondaryGunSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// 根据Index获得具体某行数据
		/// index从0开始，和excel数据表中的行对应
		/// </summary>
		public SecondaryGunSetting GetEntityByRowIndex(int index){
			if(index<0||index>count){
				Debug.LogError("index:"+index+" is not valid");
				return null;
			}
			else{
				return entities[index];
			}
		}
		/// <summary>
		/// 根据主键获得具体某行数据
		/// 需要确保主键不重复
		/// </summary>
		public SecondaryGunSetting GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(SecondaryGunSetting);
			}
		}
		/// <summary>
		/// 获得所有数据项
		/// </summary>
		public SecondaryGunSetting[] AllItems(){
			return this.entities;
		}
	}
}