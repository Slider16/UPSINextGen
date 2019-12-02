			select distinct manufactur
				from [src].[nameplat] 
				where 'manufactur' is not null 
				
				and 
					manufactur in 
					(select oldvalue from [meta].[metadatarules] 
						where tablename = 'nameplat' and fieldname = 'manufactur')
				ORDER BY manufactur




			select distinct code
				from [src].[cust] 
				where 'code' is not null 
				
				and 
					code not in 
					(select oldvalue from [meta].[metadatarules] 
						where tablename = 'cust' and fieldname = 'code')
				ORDER BY code