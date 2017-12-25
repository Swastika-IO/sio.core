import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { ArticleBackend, ModuleFullDetails, SWDataTable, FileStreamViewModel, Template, ArticleModuleNav } from "../../../viewmodels/viewmodels.component";
import { ModuleService } from '../../../services/module.service';
import { ArticleService } from '../../../services/article.services';
import { environment } from '../../../environment';
import { plainToClass } from 'class-transformer';
import { ActivatedRoute, Router } from '@angular/router';
import { ModuleDetailsService } from "../../../services/module.details.service";

@Component({
    selector: 'app-sw-portal-create-article',
    styleUrls: ['./create-article.component.scss'],
    templateUrl: './create-article.component.html',
    // encapsulation: ViewEncapsulation.None
})
export class PortalCreateArticleComponent implements OnInit {
  id: string;
  errors: string[] = [];
  ex: any;
  private sub: any;
  data = new ArticleBackend();
  activedModules: ModuleFullDetails[] = [];
  activedModule: ModuleFullDetails;

  constructor(
    private route: ActivatedRoute
    , private router: Router
    , private articleService: ArticleService
    , private moduleService: ModuleService
    , private moduleDetailsService: ModuleDetailsService
    // , private notificationService: NotificationService
    //, private spinnerSerice: Ng4LoadingSpinnerService
  ) {
    //this.ckeditorContent = `<p>My HTML</p>`;
  }

  ngOnInit() {
    
    this.sub = this.route.params.subscribe(params => {
      // In a real app: dispatch action to load the details here.
      this.data.id = params['id']; // (+) converts string 'id' to a number      
      if (this.data.id != undefined) {
        this.fetchData();
      } else {
        this.getDefaultArticle();
        
      }
    });
  }
  ngOnDestroy() {
    this.sub.unsubscribe();
  }
  getDefaultArticle(): void {
    this.articleService.getDefaultArticleWithPromise(environment.culture)
      .then(result => {
        if (result.isSucceed) {
          var subModules: SWDataTable[] = [];
          result.data.activedModules.forEach(module => {
            var sm = this.moduleDetailsService.initModuleDetails(module, this.data.id);
            subModules.push(sm);
          });
          this.data = result.data;
          this.data.subModules = subModules;
          console.log(this.data);
        } else {
          this.errors = result.errors;
          this.ex = result.ex;
          this.showErrors();
        }
      },
      error => { });
  }
  fetchData(): void {
    this.articleService.getArticleWithPromise(environment.culture, this.data.id)
      .then(result => {
        if (result.isSucceed) {
          var subModules: SWDataTable[] = [];
          result.data.activedModules.forEach(module => {
            var sm = this.moduleDetailsService.initModuleDetails(module, this.data.id);
            subModules.push(sm);
          });

          this.data = result.data;
          this.data.subModules = subModules;

        } else {
          this.errors = result.errors;
          this.ex = result.ex;
          this.showErrors();
        }
      },
      error => {
        this.errors.push(error);
        this.showErrors();
      });
  }
  setView(view: Template) {
    this.data.view = view;
  }
  submit(): void {
    //this.data.subModules.forEach(sm => {
    //  sm.source.getElements().then(result => sm.models.data = result);
    //});
    //var model = plainToClass(ArticleBackend, this.data);
    //console.log(model);
    //this.articleService.saveArticleWithPromise(environment.culture, model)
    //  .then(result => {
    //    if (result.isSucceed) {
    //      this.router.navigate(['/pages/articles/list-articles']);
    //    } else {
    //      this.errors = result.errors;
    //      this.ex = result.ex;
    //      this.showErrors();
    //    }
    //  }).catch(errors => {
    //    //this.spinnerSerice.hide();
    //  }
    //  );
    console.log(this.data);

  }
  showErrors(): void {
    if (this.errors) {
      this.errors.forEach(element => {
        // this.notificationService.makeToast('error', '', element);
      });
    }

  }
  onSelectFile(type: string, event: any): void {
    var myReader: FileReader = new FileReader();
    if (event.action === 1) {
      if (type === 'image') {

        myReader.readAsDataURL(event.file);
        myReader.onloadend = (e) => {
          this.data.imageUrl = myReader.result;
          this.data.imageFileStream = new FileStreamViewModel()
          this.data.imageFileStream.base64 = myReader.result
          this.data.imageFileStream.name = event.file.name;
          this.data.imageFileStream.type = event.file.type;
          this.data.imageFileStream.size = event.file.size;
        }
      } else {
        myReader.readAsDataURL(event.file);
        myReader.onloadend = (e) => {
          this.data.thumbnailUrl = myReader.result;
          this.data.thumbnailFileStream = new FileStreamViewModel()
          this.data.thumbnailFileStream.base64 = myReader.result
          this.data.thumbnailFileStream.name = event.file.name;
          this.data.thumbnailFileStream.type = event.file.type;
          this.data.thumbnailFileStream.size = event.file.size;
        }

      }
    }
  }

  onChange(navigation: ArticleModuleNav) {
    if (this.data.id != null) {
      const addUrl = 'api/' + navigation.specificulture + '/modules/addToArticle';
      if (!navigation.isActived && !confirm("The data will be deleted too!")) {
        return;
      }

      this.modifyActivedModules(navigation);
      // this.moduleDetailsService.addToArticle(addUrl, navigation).then(addResult => {
      //   if (addResult.isSucceed) {
      //     this.modifyActivedModules(navigation);
      //   } else {
      //     this.errors = addResult.errors;
      //     this.ex = addResult.ex;
      //     this.showErrors();
      //   }
      // });
    } else {
      this.modifyActivedModules(navigation);
    }

  }
  modifyActivedModules(navigation: ArticleModuleNav): void {
    if (navigation.isActived) {
      this.moduleService.getFullModuleByArticle(navigation.specificulture, navigation.moduleId, this.data.id)
        .then(result => {
          if (result.isSucceed) {
            var sm = this.moduleDetailsService.initModuleDetails(result.data, this.data.id);
            this.data.subModules.push(sm);
            this.data.activedModules.push(result.data);
          } else {
            this.errors = result.errors;
            this.ex = result.ex;
            this.showErrors();
          }
        });
    }
    else {
      var index = this.data.activedModules.findIndex(a => a.id == navigation.moduleId);
      if (index > -1) {
        this.data.activedModules.splice(index, 1);
        this.data.subModules.splice(index, 1);
      }
    }
  }
}
