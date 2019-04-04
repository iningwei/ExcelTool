using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class SecondaryGunSetting_table{
		private SecondaryGunSetting[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		/// <summary>
		/// 数量
		/// </summary>
		 public int Count{
			get{ return this.count;}
		}

		static SecondaryGunSetting_table instance=null;
		public static SecondaryGunSetting_table Instance{
			get{
				if(instance==null){
					instance=new SecondaryGunSetting_table();
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
					entities[i].ID=vals[0]=="囧"?0:int.Parse(vals[0].Trim());
					entities[i].Name=vals[1]=="囧"?0:int.Parse(vals[1].Trim());
					entities[i].UnitType=vals[2]=="囧"?0:int.Parse(vals[2].Trim());
					entities[i].Speed=vals[3]=="囧"?0:float.Parse(vals[3].Trim());
					entities[i].Damage=vals[4]=="囧"?0:float.Parse(vals[4].Trim());
					entities[i].Defence=vals[5]=="囧"?0:float.Parse(vals[5].Trim());
					entities[i].CoinReward=vals[6]=="囧"?0:float.Parse(vals[6].Trim());
					entities[i].CoinPrice=vals[7]=="囧"?0:float.Parse(vals[7].Trim());
					entities[i].DefaultLv=vals[8]=="囧"?0:int.Parse(vals[8].Trim());
					entities[i].MaxLv=vals[9]=="囧"?0:int.Parse(vals[9].Trim());
					entities[i].UnlockType=vals[10]=="囧"?0:int.Parse(vals[10].Trim());
					entities[i].UnlockValue=vals[11]=="囧"?0:int.Parse(vals[11].Trim());
					entities[i].AtlasName=vals[12]=="囧"?null:vals[12].Trim();
					entities[i].SpriteName=vals[13]=="囧"?null:vals[13].Trim();
					entities[i].PropertyPlus=vals[14]=="囧"?null:vals[14].Trim();
					entities[i].BulletPrefabName=vals[15]=="囧"?null:vals[15].Trim();
					entities[i].BulletName=vals[16]=="囧"?null:vals[16].Trim();
					keyIndexMap[entities[i].ID]=i;
				}
			};

			string fileName=SecondaryGunSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// 根据Index获得具体某行数据
		/// index从0开始，对应excel数据中的对应行
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