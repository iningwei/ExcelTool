using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ZGame.ZTable{
	public class LanguageSettingReader{
		private LanguageSetting[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static LanguageSettingReader instance=null;
		public static LanguageSettingReader Instance{
			get{
				if(instance==null){
					instance=new LanguageSettingReader();
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
				entities=new LanguageSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new LanguageSetting();
					entities[i].Id=int.Parse(vals[0].Trim());
					entities[i].Value=vals[1];
					keyIndexMap[entities[i].Id]=i;
				}
			};

			string fileName=LanguageSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// get datas of a row by Index
		/// index starts form 0,which marching the line 7 of excel table
		/// </summary>
		public LanguageSetting GetEntityByRowIndex(int index){
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
		public LanguageSetting GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(LanguageSetting);
			}
		}
		/// <summary>
		/// get all row datas
		/// </summary>
		public LanguageSetting[] AllItems(){
			return this.entities;
		}
	}
}