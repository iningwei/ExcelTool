using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ZGame.ZTable{
	public class GameSettingReader{
		private GameSetting[] entities;
		private Dictionary<string,int> keyIndexMap = new Dictionary<string,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static GameSettingReader instance=null;
		public static GameSettingReader Instance{
			get{
				if(instance==null){
					instance=new GameSettingReader();
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
				entities=new GameSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new GameSetting();
					entities[i].Key=vals[0];
					entities[i].Value=(object)(vals[1].Trim());
					keyIndexMap[entities[i].Key]=i;
				}
			};

			string fileName=GameSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// get datas of a row by Index
		/// index starts form 0,which marching the line 7 of excel table
		/// </summary>
		public GameSetting GetEntityByRowIndex(int index){
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
		public GameSetting GetEntityByPrimaryKey(string key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(GameSetting);
			}
		}
		/// <summary>
		/// get all row datas
		/// </summary>
		public GameSetting[] AllItems(){
			return this.entities;
		}
	}
}