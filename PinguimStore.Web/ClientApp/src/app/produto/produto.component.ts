import { Component, OnInit } from "@angular/core"
import { Router } from "@angular/router";

@Component({
  selector: "app-produto",
  template: "<html><body>{{ obterNome() }}</body></html>"//"./produto.component.html",
  //styleUrls: ["./produto.component.css"]
})
export class ProdutoComponent { //TypeScript - Nome de classe utiliza PascalCase

  //TypeScript utiliza CAMELCASE para variaveis,atributos e nome das funcoes
  public nome: string;
  public liberadoParaVenda: boolean;

  public obterNome(): string {
    return "Huawei";
  }
}
