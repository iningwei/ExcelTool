﻿using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class TestReader{
		private Test[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static TestReader instance=null;
		public static TestReader Instance{
			get{
				if(instance==null){
					instance=new TestReader();
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
				entities=new Test[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new Test();
					entities[i].ID=int.Parse(vals[0].Trim());
					entities[i].Name=vals[1];
					entities[i].PrefabName=vals[2];
					entities[i].Test2=vals[3].Split('|').ToIntArray();
					entities[i].MoveSpeed=vals[4].Split('|').ToFloatArray();
					keyIndexMap[entities[i].ID]=i;
				}
			};

			string fileName=Test.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// 根据Index获得具体某行数据
		/// index从0开始，和excel数据表中的行对应
		/// </summary>
		public Test GetEntityByRowIndex(int index){
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
		public Test GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(Test);
			}
		}
		/// <summary>
		/// 获得所有数据项
		/// </summary>
		public Test[] AllItems(){
			return this.entities;
		}
	}
}