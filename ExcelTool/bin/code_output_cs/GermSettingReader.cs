using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class GermSettingReader{
		private GermSetting[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static GermSettingReader instance=null;
		public static GermSettingReader Instance{
			get{
				if(instance==null){
					instance=new GermSettingReader();
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
				entities=new GermSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new GermSetting();
					entities[i].ID=int.Parse(vals[0].Trim());
					entities[i].Name=vals[1];
					entities[i].PrefabName=vals[2];
					entities[i].Radius=float.Parse(vals[3].Trim());
					entities[i].MoveSpeed=float.Parse(vals[4].Trim());
					keyIndexMap[entities[i].ID]=i;
				}
			};

			string fileName=GermSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// get datas of a row by Index
		/// index starts form 0,which marching the line 7 of excel table
		/// </summary>
		public GermSetting GetEntityByRowIndex(int index){
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
		public GermSetting GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(GermSetting);
			}
		}
		/// <summary>
		/// get all row datas
		/// </summary>
		public GermSetting[] AllItems(){
			return this.entities;
		}
	}
}