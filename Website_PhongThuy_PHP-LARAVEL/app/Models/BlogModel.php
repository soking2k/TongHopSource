<?php
namespace App\Models;
use Illuminate\Database\Eloquent\Model;
use DB;
class BlogModel extends Model
{
    protected $table = 'users';
    protected $fillable = ['id', 'username', 'password'];
    public $timestamps = false;
}