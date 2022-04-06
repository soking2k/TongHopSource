<?php
namespace App\Http\Controllers; 
use Illuminate\Contracts\Auth\MustVerifyEmail;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Illuminate\Notifications\Notifiable;
use Session;
use DB;
use illuminate\Http\Request;
use illuminate\Support\Facades\Redirect;
use App\Models\BlogModel;
 
class BlogController extends Controller {
    // ================== THÊM THÀNH VIÊN
    public function create()
    {
        return view('register');
    }
    public function insert(Request $request) {
        $this->validate(request(), [
            'username' => 'required',
            'password' => 'required'
        ]);
        
        BlogModel::create(request(['username', 'password']));
        echo '<script language="javascript">alert("Thêm thành viên thành công!");</script>';
    }
    
    public function users_list(){
        $value=DB::table('users')->get();
        return view('home')->with('viewdata', $value);
    }
    public function edit(Request $request,$id) {
        $data = DB::table('LoaiSP')->find($id); 
        
        return view('edit',compact('data')); 
    }
    public function update(Request $request, $id)
        {
        $data = BlogModel::find($id);
    //    $data->username = $request->username;
     //   $data->password = $request->password;
        $data->username = "check";
        $data->password = "check1";
        $data->save();
        echo '<script language="javascript">alert("Cập nhật thành viên thành công!");</script>';
    }
    public function delete(Request $request, $id) {
        BlogModel::where('id',$id)->delete();
          echo '<script language="javascript">alert("Xóa thành viên thành công!");</script>';
   }
}