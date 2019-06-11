using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class BulletSettingReader{
		private BulletSetting[] entities;
		private Dictionary<string,int> keyIndexMap = new Dictionary<string,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static BulletSettingReader instance=null;
		public static BulletSettingReader Instance{
			get{
				if(instance==null){
					instance=new BulletSettingReader();
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
				entities=new BulletSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new BulletSetting();
					entities[i].Name=vals[0];
					entities[i].MoveSpeed=float.Parse(vals[1].Trim());
					entities[i].HitType=int.Parse(vals[2].Trim());
					entities[i].Area=float.Parse(vals[3].Trim());
					entities[i].AutoDestroyType=int.Parse(vals[4].Trim());
					entities[i].LifeTime=float.Parse(vals[5].Trim());
					entities[i].Ylength=float.Parse(vals[6].Trim());
					entities[i].HarmInterval=float.Parse(vals[7].Trim());
					entities[i].UniqueParams=vals[8].Split('|').ToFloatArray();
					entities[i].RestrictPos=bool.Parse(vals[9].Trim());
					entities[i].HasPrepareAnim=bool.Parse(vals[10].Trim());
					entities[i].HasVanishAnim=bool.Parse(vals[11].Trim());
					entities[i].HasHitEffect=bool.Parse(vals[12].Trim());
					entities[i].HitEffectName=vals[13];
					entities[i].BoomAudioName=vals[14];
					keyIndexMap[entities[i].Name]=i;
				}
			};

			string fileName=BulletSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// get datas of a row by Index
		/// index starts form 0,which marching the line 7 of excel table
		/// </summary>
		public BulletSetting GetEntityByRowIndex(int index){
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
		public BulletSetting GetEntityByPrimaryKey(string key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(BulletSetting);
			}
		}
		/// <summary>
		/// get all row datas
		/// </summary>
		public BulletSetting[] AllItems(){
			return this.entities;
		}
	}
}