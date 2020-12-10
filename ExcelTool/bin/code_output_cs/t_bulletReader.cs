using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ZGame.ZTable{
	public class t_bulletReader{
		private t_bullet[] entities;
		private Dictionary<string,int> keyIndexMap = new Dictionary<string,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static t_bulletReader instance=null;
		public static t_bulletReader Instance{
			get{
				if(instance==null){
					instance=new t_bulletReader();
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
				entities=new t_bullet[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new t_bullet();
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

			string fileName=t_bullet.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// get datas of a row by Index
		/// index starts form 0,which marching the line 7 of excel table
		/// </summary>
		public t_bullet GetEntityByRowIndex(int index){
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
		public t_bullet GetEntityByPrimaryKey(string key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(t_bullet);
			}
		}
		/// <summary>
		/// get all row datas
		/// </summary>
		public t_bullet[] AllItems(){
			return this.entities;
		}
	}
}