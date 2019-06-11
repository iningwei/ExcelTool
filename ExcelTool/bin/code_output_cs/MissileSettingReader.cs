using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class MissileSettingReader{
		private MissileSetting[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static MissileSettingReader instance=null;
		public static MissileSettingReader Instance{
			get{
				if(instance==null){
					instance=new MissileSettingReader();
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
				entities=new MissileSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new MissileSetting();
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
					entities[i].SmoothDamp=bool.Parse(vals[19].Trim());
					entities[i].HasShootAnim=bool.Parse(vals[20].Trim());
					entities[i].ShootAudioName=vals[21];
					keyIndexMap[entities[i].ID]=i;
				}
			};

			string fileName=MissileSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// get datas of a row by Index
		/// index starts form 0,which marching the line 7 of excel table
		/// </summary>
		public MissileSetting GetEntityByRowIndex(int index){
			if(index<0||index>count){
				Debug.LogError("index:"+index+" is not valid");
				return null;
			}
			else{
				return entities[index];
			}
		}
		/// <summary>
		/// get datas of a row by primary key
		/// </summary>
		public MissileSetting GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(MissileSetting);
			}
		}
		/// <summary>
		/// get all row datas
		/// </summary>
		public MissileSetting[] AllItems(){
			return this.entities;
		}
	}
}