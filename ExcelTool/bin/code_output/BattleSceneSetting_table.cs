﻿using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class BattleSceneSetting_table{
		private BattleSceneSetting[] entities;
		private Dictionary<string,int> keyIndexMap = new Dictionary<string,int>();

		private int count;
		/// <summary>
		/// 数量
		/// </summary>
		 public int Count{
			get{ return this.count;}
		}

		static BattleSceneSetting_table instance=null;
		public static BattleSceneSetting_table Instance{
			get{
				if(instance==null){
					instance=new BattleSceneSetting_table();
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
				entities=new BattleSceneSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new BattleSceneSetting();
					entities[i].Key= vals[0].Trim();
					entities[i].Value=float.Parse(vals[1].Trim());
					keyIndexMap[entities[i].Key]=i;
				}
			};

			string fileName=BattleSceneSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// 根据Index获得具体某行数据
		/// index从0开始，对应excel数据中的对应行
		/// </summary>
		public BattleSceneSetting GetEntityByRowIndex(int index){
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
		public BattleSceneSetting GetEntityByPrimaryKey(string key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(BattleSceneSetting);
			}
		}
	}
}