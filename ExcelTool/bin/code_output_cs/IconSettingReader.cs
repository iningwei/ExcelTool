﻿using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class IconSettingReader{
		private IconSetting[] entities;
		private Dictionary<string,int> keyIndexMap = new Dictionary<string,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static IconSettingReader instance=null;
		public static IconSettingReader Instance{
			get{
				if(instance==null){
					instance=new IconSettingReader();
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
				entities=new IconSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new IconSetting();
					entities[i].Key=vals[0];
					entities[i].Value=vals[1].Split('|');
					keyIndexMap[entities[i].Key]=i;
				}
			};

			string fileName=IconSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// get datas of a row by Index
		/// index starts form 0,which marching the line 7 of excel table
		/// </summary>
		public IconSetting GetEntityByRowIndex(int index){
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
		public IconSetting GetEntityByPrimaryKey(string key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(IconSetting);
			}
		}
		/// <summary>
		/// get all row datas
		/// </summary>
		public IconSetting[] AllItems(){
			return this.entities;
		}
	}
}