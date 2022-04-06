<?php
  
namespace App\Http\Controllers;
  
use App\Models\TestModel;
use Illuminate\Http\Request;
  
class TestController extends Controller {
    public function home() {
        $articles = \App\Models\TestModel::all();
        var_dump($articles);
    }
  
    public function insert() {
        $article = new TestModel;
        $article->username = "admin-new";
        $article->password = "123456";
        $article->save();
        echo "Thêm dữ liệu thành công!";
    }
      
    public function update() {
        $article = \App\Models\TestModel::find(11);
        $article->username = "Laravel";
        $article->save();
        echo "Cập nhật thành công!";
    }
      
    public function delete() {
        $article = \App\Models\TestModel::find(11);
        $article->delete();
        echo "Xóa thành công!";
    }
}