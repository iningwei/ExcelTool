using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ZGame.ZTable{
	public class EffectSettingReader{
		private EffectSetting[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static EffectSettingReader instance=null;
		public static EffectSettingReader Instance{
			get{
				if(instance==null){
					instance=new EffectSettingReader();
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
				entities=new EffectSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new EffectSetting();
					entities[i].ID=int.Parse(vals[0].Trim());
					entities[i].ResName=vals[1];
					entities[i].ResType=vals[2];
					entities[i].Time=float.Parse(vals[3].Trim());
					keyIndexMap[entities[i].ID]=i;
				}
			};

			string fileName=EffectSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// get datas of a row by Index
		/// index starts form 0,which marching the line 7 of excel table
		/// </summary>
		public EffectSetting GetEntityByRowIndex(int index){
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
		public EffectSetting GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(EffectSetting);
			}
		}
		/// <summary>
		/// get all row datas
		/// </summary>
		public EffectSetting[] AllItems(){
			return this.entities;
		}
	}
}