using UnityEngine;
using System.Collections;


public class numeric
{
	public static float epsilon = 2.220446049250313e-16f;

	public static float[][] diag(float[] d)
	{
		int i,i1,j, n = d.Length;
		float[][] A = new float[n][];
		float[] Ai;

		for(i=n-1;i>=0;i--) {
			Ai = new float[n];
			i1 = i+2;
			for(j=n-1;j>=i1;j-=2) {
				Ai[j] = 0;
				Ai[j-1] = 0;
			}
			if(j>i) { Ai[j] = 0; }
			Ai[i] = d[i];
			for(j=i-1;j>=1;j-=2) {
				Ai[j] = 0;
				Ai[j-1] = 0;
			}
			if(j==0) { Ai[0] = 0; }
			A[i] = Ai;
		}
		return A;
	}
	public static float[] linspace(float a, float b)
	{

		int n = (int)Mathf.Max(Mathf.Round(b-a)+1,1);
			//max(Mathf.round(b-a)+1,1);

		float[] ret = new float[n];
		n--;
		for(int i=n;i>=0;i--) 
		{ 
			ret[i] = (i*b+(n-i)*a)/n; 
		}
		return ret;
	}
	public static float[] linspace(float a, float b, int n)
	{
		
		float[] ret = new float[n];
		n--;
		for(int i=n;i>=0;i--) 
		{ 
			ret[i] = (i*b+(n-i)*a)/n; 
		}
		return ret;
	}

	public static float[][] rep(int[] s, int v)
	{
		//if(k == null) { k=0; }
		float[][] ret; 
		if(s.Length == 1)
		{
			ret = new float[][] {new float[s[0]]};
			for(int i=0;i<1;i++)
			{

				for(int j=0;j<s[0];j++)
				{

					ret[i][j]=v;

				}
			}
		}
		else if(s.Length == 2)
		{
			ret = new float[s[0]][];
			for(int i=0;i<s[0];i++)
			{
				ret[i] = new float[s[1]];
				for(int j=0;j<s[1];j++)
				{
					ret[i][j]=v;
				}
			}
		}
		else
		{
			Debug.LogError("Going into 3D now");
			return null;
		}

		return ret;
	}
	public static int[] dim(float[][] A) 
	{
//		if(typeof ret === "undefined") { ret = []; }
//		if(typeof A !== "object") return ret;
//		if(typeof k === "undefined") { k=0; }
		//if(!(k in ret)) { ret[k] = 0; }
		//if(A.Length > ret[k]) ret[k] = A.length;
		int[] ret;
		if(A.Length==1)
		{
			ret = new int[1]{A[0].Length};
		}
		else
		{
			ret = new int[2]{A.Length,A[0].Length};
		}

		return ret;
	}
	public static float pythag(float a, float b)
	{

		a = Mathf.Abs(a);
		b = Mathf.Abs(b);
		if (a > b)
			return a*Mathf.Sqrt(1.0f+((b*b)/(a*a)));
		else if (b == 0.0f) 
			return a;

		return b*Mathf.Sqrt(1.0f+(a*a/(b*b)));


	}


	public static float[][] clone(float[][] A) 
	{
		float[][] ret = new float[A.Length][];
		for(int i=0; i<A.Length;i++)
		{
			ret[i] = new float[A[i].Length];
			for(int j=0;j<A[i].Length;j++)
			{
				ret[i][j] = A[i][j];
			}
		}
		return ret;
	}
	public static float[] clone(float[] A) 
	{
		float[] ret = new float[A.Length];
		for(int i=0; i<A.Length;i++)
		{
			ret[i] = A[i];

		}
		return ret;
	}

	public static float[][] transpose(float[][] x) 
	{
		int m = x.Length,n = x[0].Length;
		float[][] ret;
		float[] A0,A1,Bj;
		 

		ret = new float[n][];
		for(int i=0;i<n;i++)
		{
			ret[i]= new float[m];
			for(int j=0;j<m;j++)
			{
				ret[i][j] = x[j][i];
			}
		}

//		A0 = new float[n];
//		A1 = new float[n];
//		Bj = new float[m];
//		ret = new float[m][];
//
//		for(i=m-1;i>=1;i-=2) 
//		{
//			A1 = x[i];
//			A0 = x[i-1];
//			ret[i] = new float[n];
//			Bj[i]=0;
//			for(j=n-1;j>=1;--j) 
//			{
//				Debug.Log (Bj[i]);
//				Bj = ret[j]; 
//				Bj[i] = A1[j]; 
//				Bj[i-1] = A0[j];
//				--j;
//				Bj = ret[j]; 
//				Bj[i] = A1[j]; 
//				Bj[i-1] = A0[j];
//
//			}
//			if(j==0) 
//			{
//				Bj = ret[0]; 
//				Bj[i] = A1[0]; 
//				Bj[i-1] = A0[0];
//			}
//		}
//		if(i==0) 
//		{
//			A0 = x[0];
//			for(j=n-1;j>=1;--j) {
//				ret[j][0] = A0[j];
//				--j;
//				ret[j][0] = A0[j];
//			}
//			if(j==0) { ret[0][0] = A0[0]; }
//		}
		return ret;
	}
	public static object svd(float[][] A)
	{
		float temp;
		//Compute the thin SVD from G. H. Golub and C. Reinsch, Numer. Mathf. 14, 403-420 (1970)
		float prec= epsilon; //Mathf.pow(2,-52) // assumes double prec
		float tolerance= 1e-64f/prec;
		float itmax= 50;
		float c=0f;
		int i=0;
		int j=0;
		int k=0;
		int l=0;


		float[][] u = clone(A);

		int m = u.Length;
		
		int n = u[0].Length;

		if (m < n) Debug.LogError("Need more rows than columns");
			
		float[] e = new float[n];
		float[] q = new float[n];

		for (i=0; i<n; i++) 
		{
			e[i] = 0.0f;
			q[i] = 0.0f;
		}

		int[] nn = new int[]{n,n};
		float[][] v = rep(nn,0);


		//	v.zero();
		

		
		//Householder's reduction to bidiagonal form
		
		float f= 0.0f;
		float g= 0.0f;
		float h= 0.0f;
		float x= 0.0f;
		float y= 0.0f;
		float z= 0.0f;
		float s= 0.0f;

		for (i=0; i < n; i++)
		{	
			e[i]= g;
			s= 0.0f;
			l= i+1;
			for (j=i; j < m; j++) 
				s += (u[j][i]*u[j][i]);
			if (s <= tolerance)
				g= 0.0f;
			else
			{	
				f= u[i][i];
				g= Mathf.Sqrt(s);
				if (f >= 0.0f) g= -g;
				h= f*g-s;
				u[i][i]=f-g;
				for (j=l; j < n; j++)
				{
					s= 0.0f;
					for (k=i; k < m; k++) 
						s += u[k][i]*u[k][j];
					f= s/h;
					for (k=i; k < m; k++) 
						u[k][j]+=f*u[k][i];
				}
			}
			q[i]= g;
			s= 0.0f;
			for (j=l; j < n; j++) 
				s= s + u[i][j]*u[i][j];
			if (s <= tolerance)
			g= 0.0f;
			else
			{	
				f= u[i][i+1];
				g= Mathf.Sqrt(s);
				if (f >= 0.0f) g= -g;
					h= f*g - s;
				u[i][i+1] = f-g;
				for (j=l; j < n; j++) e[j]= u[i][j]/h;
				for (j=l; j < m; j++)
				{	
					s=0.0f;
					for (k=l; k < n; k++) 
						s += (u[j][k]*u[i][k]);
					for (k=l; k < n; k++) 
						u[j][k]+=s*e[k];
				}	
			}
		y= Mathf.Abs(q[i])+Mathf.Abs(e[i]);
		if (y>x) 
			x=y;
		}

		// accumulation of right hand gtransformations
		for (i=n-1; i != -1; i+= -1)
		{	
			if (g != 0.0f)
			{
				h= g*u[i][i+1];
				for (j=l; j < n; j++) 
					v[j][i]=u[i][j]/h;
				for (j=l; j < n; j++)
				{	
					s=0.0f;
					for (k=l; k < n; k++) 
						s += u[i][k]*v[k][j];
					for (k=l; k < n; k++) 
						v[k][j]+=(s*v[k][i]);
				}	
			}
			for (j=l; j < n; j++)
			{
				v[i][j] = 0;
				v[j][i] = 0;
			}
			v[i][i] = 1;
			g= e[i];
			l= i;
		}

		// accumulation of left hand transformations
		for (i=n-1; i != -1; i+= -1)
		{	
			l= i+1;
			g= q[i];
			for (j=l; j < n; j++) 
				u[i][j] = 0;
			if (g != 0.0f)
			{
				h= u[i][i]*g;
				for (j=l; j < n; j++)
				{
					s=0.0f;
					for (k=l; k < m; k++) s += u[k][i]*u[k][j];
					f= s/h;
					for (k=i; k < m; k++) u[k][j]+=f*u[k][i];
				}
				for (j=i; j < m; j++) u[j][i] = u[j][i]/g;
			}
			else
				for (j=i; j < m; j++) u[j][i] = 0;
			u[i][i] += 1;
		}


		// diagonalization of the bidiagonal form
		prec= prec*x;
		for (k=n-1; k != -1; k+= -1)
		{
			for (float iteration=0; iteration < itmax; iteration++)
			{	// test f splitting
				bool test_convergence = false;
				for (l=k; l != -1; l+= -1)
				{	
					if (Mathf.Abs(e[l]) <= prec)
					{	
						test_convergence = true;
						break ;
					}
					if (Mathf.Abs(q[l-1]) <= prec)
					break; 
				}
				if (!test_convergence)
				{	// cancellation of e[l] if l>0
					c = 0;
					s= 1.0f;
					int l1= l-1;
					for (i =l; i<k+1; i++)
					{	
						f= s*e[i];
						e[i]= c*e[i];
						if (Mathf.Abs(f) <= prec)
							break;
						g= q[i];
						h= pythag(f,g);
						q[i]= h;
						c= g/h;
						s= -f/h;
						for (j=0; j < m; j++)
						{	
							y= u[j][l1];
							z= u[j][i];
							u[j][l1] =  y*c+(z*s);
							u[j][i] = -y*s+(z*c);
						} 
					}	
				}					
	
				// test f convergence
				z= q[k];
				if (l == k)
				{	//convergence
					if (z<0.0f)
					{	//q[k] is made non-negative
						q[k]= -z;
						for (j=0; j < n; j++)
							v[j][k] = -v[j][k];
					}
					break;  //break out of iteration loop and move on to next k value
				}
				if (iteration >= itmax-1)
					Debug.LogError("Error: no convergence.");
						// shift from bottom 2x2 minor
				x= q[l];
				y= q[k-1];
				g= e[k-1];
				h= e[k];
				f= ((y-z)*(y+z)+(g-h)*(g+h))/(2.0f*h*y);
				g= pythag(f,1.0f);
				if (f < 0.0f)
					f= ((x-z)*(x+z)+h*(y/(f-g)-h))/x;
				else
					f= ((x-z)*(x+z)+h*(y/(f+g)-h))/x;
									// next QR transformation
				c= 1.0f;
				s= 1.0f;
				for (i=l+1; i< k+1; i++)
				{	
					g= e[i];
					y= q[i];
					h= s*g;
					g= c*g;
					z= pythag(f,h);
					e[i-1]= z;
					c= f/z;
					s= h/z;
					f= x*c+g*s;
					g= -x*s+g*c;
					h= y*s;
					y= y*c;
					for (j=0; j < n; j++)
					{	
						x= v[j][i-1];
						z= v[j][i];
						v[j][i-1] = x*c+z*s;
						v[j][i] = -x*s+z*c;
					}
					z= pythag(f,h);
					q[i-1]= z;
					c= f/z;
					s= h/z;
					f= c*g+s*y;
					x= -s*g+c*y;
					for (j=0; j < m; j++)
					{
						y= u[j][i-1];
						z= u[j][i];
						u[j][i-1] = y*c+z*s;
						u[j][i] = -y*s+z*c;
					}
				}
				e[l]= 0.0f;
				e[k]= f;
				q[k]= x;
			} 
		}

		//vt= transpose(v)
		//return (u,q,vt)
		for (i=0;i<q.Length; i++) 
			if (q[i] < prec) 
				q[i] = 0;
				
		//sort eigenvalues	
		for (i=0; i< n; i++)
		{	 
			//writeln(q)
			for (j=i-1; j >= 0; j--)
			{
				if (q[j] < q[i])
				{
					//  writeln(i,'-',j)
					c = q[j];
					q[j] = q[i];
					q[i] = c;
					for(k=0;k<u.Length;k++) { temp = u[k][i]; u[k][i] = u[k][j]; u[k][j] = temp; }
					for(k=0;k<v.Length;k++) { temp = v[k][i]; v[k][i] = v[k][j]; v[k][j] = temp; }
					//	   u.swapCols(i,j)
					//	   v.swapCols(i,j)
					i = j;   
				}
			}	
		}
		object[] obj = new object[3];
		obj[0] = u;
		obj[1] = q;
		obj[2] = v;
		//return null;
		return obj;

	}

}